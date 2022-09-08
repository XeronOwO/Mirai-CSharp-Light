using Mirai.CSharp.Light.Exception;
using Mirai.CSharp.Light.Extensions;
using Mirai.CSharp.Light.Handler;
using Mirai.CSharp.Light.Logger;
using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Session;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Web;

#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning disable CS8601 // 引用类型赋值可能为 null。
#pragma warning disable CS8602 // 解引用可能出现空引用。
#pragma warning disable CS8604 // 引用类型参数可能为 null。
#pragma warning disable IDE0038 // 使用模式匹配
namespace Mirai.CSharp.Light
{
	/// <summary>
	/// MiraiCSharpLight类，使用HTTP Adapter
	/// </summary>
	public class MiraiCSharpLight
	{
		/// <summary>
		/// 验证密钥。<br/>
		/// 详见：<see href="https://github.com/project-mirai/mirai-api-http">Mirai-Api-Http</see>
		/// </summary>
		public string VerifyKey { get; set; } = string.Empty;

		private MiraiSession? miraiSession;

		/// <summary>
		/// 获取Mirai会话
		/// </summary>
		public IMiraiSession? MiraiSession => miraiSession;

		/// <summary>
		/// 绑定的Bot的QQ号
		/// </summary>
		public long QQ { get; set; } = 0L;

		private readonly List<object> handlers = new();

		/// <summary>
		/// 添加handler
		/// </summary>
		/// <param name="handler">handler</param>
		public void AddHandler(object handler)
		{
			handlers.Add(handler);
		}

		/// <summary>
		/// 删除handler
		/// </summary>
		/// <param name="handler">handler</param>
		public void RemoveHandler(object handler)
		{
			handlers.Remove(handler);
		}

		private readonly MiraiCSharpLightLogger logger = MiraiCSharpLightLogger.GetLogger("MiraiCSharpLight");

		/// <summary>
		/// 连接到Mirai-Api-Http，连接即视为开始运行
		/// </summary>
		/// <param name="url">Mirai-Api-Http服务的URL，例如"http://0.0.0.0:12345"</param>
		/// <exception cref="MiraiException"></exception>
		public void Connect(string url)
		{
			if (QQ == 0)
			{
				throw new MiraiException("MiraiCSharpLight", "未设置Bot的QQ号");
			}
			miraiSession = new()
			{
				httpClient = new()
				{
					BaseAddress = new Uri(url),
				}
			};
			isAlive = true;
			JObject result;
			result = miraiSession.Post("verify", new JObject()
			{
				["verifyKey"] = VerifyKey,
			});
			miraiSession.SessionKey = (string)result["session"];
			logger.Info($"VerifyKey验证成功，SessionKey：{miraiSession.SessionKey}");
			miraiSession.Post("bind", new JObject()
			{
				["sessionKey"] = miraiSession.SessionKey,
				["qq"] = QQ,
			});
			logger.Info($"绑定QQ[{QQ}]成功");
			result = miraiSession.Get("sessionInfo", new JObject()
			{
				["sessionKey"] = miraiSession.SessionKey,
			});
			miraiSession.BotData_ = UserData.Parse((JObject)result["data"]["qq"]);
			result = miraiSession.Get("about");
			var ver = (string)result["data"]["version"];
			if (ver.StartsWith('v'))
			{
				ver = ver.Substring(1);
			}
			miraiSession.APIVersion = Version.Parse(ver);
			logger.Info($"获取到Mirai-Api-Http版本：{miraiSession.APIVersion}");
			if (miraiSession.APIVersion < Version.Parse("2.4.0"))
			{
				logger.Warning("Mirai-Api-Http版本低于2.4.0，部分功能可能导致异常");
			}
			StartMessageLoop();
		}

		/// <summary>
		/// 异步连接到Mirai-Api-Http，连接即视为开始运行
		/// </summary>
		/// <param name="url">Mirai-Api-Http服务的URL，例如"http://0.0.0.0:12345"</param>
		/// <exception cref="MiraiException"></exception>
		public Task ConnectAsync(string url) => Task.Run(() => Connect(url));

		private bool isAlive = false;

		/// <summary>
		/// 是否在线，即是否在正常运行
		/// </summary>
		public bool IsAlive { get => isAlive; }

		/// <summary>
		/// MiraiLight析构函数
		/// </summary>
		~MiraiCSharpLight()
		{
			if (IsAlive)
			{
				Release();
			}
		}

		/// <summary>
		/// 释放MiraiLight相关资源
		/// </summary>
		/// <exception cref="MiraiException"></exception>
		public void Release()
		{
			StopMessageLoop();
			miraiSession.Post("release", new JObject()
			{
				["sessionKey"] = miraiSession.SessionKey,
				["qq"] = QQ,
			});
			logger.Info("发送Release给Mirai-Api-Http成功");
			miraiSession = null;
			isAlive = false;
			logger.Info("成功释放本地资源");
		}

		private Thread? MessageLoopThread;

		private bool MessageLoopExit;

		private void StartMessageLoop()
		{
			MessageLoopThread = new Thread(new ThreadStart(MessageLoopFunc));
			MessageLoopThread.Start();
		}

		private void StopMessageLoop()
		{
			if (MessageLoopThread == null)
			{
				return;
			}
			if (MessageLoopThread.IsAlive)
			{
				MessageLoopExit = true;
				MessageLoopThread.Join();
				MessageLoopExit = false;
			}
			MessageLoopThread = null;
		}

		private void MessageLoopFunc()
		{
			while (!MessageLoopExit)
			{
				var result = miraiSession.Get("countMessage", new JObject()
				{
					["sessionKey"] = MiraiSession.SessionKey,
				});
				var count = (int)result["data"];
				if (count > 0)
				{
					var result2 = miraiSession.Get("fetchMessage", new JObject()
					{
						["sessionKey"] = MiraiSession.SessionKey,
						["count"] = count,
					});
					foreach (var item in (JArray)result2["data"])
					{
						HandleMessage((JObject)item);
					}
				}

				Thread.Sleep(100);
			}
		}

		private void HandleMessage(JObject message)
		{
			switch ((string)message["type"])
			{
				#region 消息

				case "GroupMessage":
					{
						var e = GroupMessageData.Parse(message);
						logger.Info($"[GroupMessage:{e.Sender.Group.Id}] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IGroupMessageHandler)
							{
								// 不是所有消息都做了Parse，所以有的不支持的消息不调用Handler
								if (e.MessageChain.Length > 0)
								{
									if (((IGroupMessageHandler)handler).HandleGroupMessage(miraiSession, e))
									{
										break;
									}
								}
							}
						}
					}
					break;
				case "FriendMessage":
					{
						var e = FriendMessageData.Parse(message);
						logger.Info($"[FriendMessage:{e.Sender.Id}] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IFriendMessageHandler)
							{
								if (e.MessageChain.Length > 0)
								{
									if (((IFriendMessageHandler)handler).HandleFriendMessage(miraiSession, e))
									{
										break;
									}
								}
							}
						}
					}
					break;
				case "TempMessage":
					{
						var e = TempMessageData.Parse(message);
						logger.Info($"[TempMessage:{e.Sender.Id}] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is ITempMessageHandler)
							{
								if (e.MessageChain.Length > 0)
								{
									if (((ITempMessageHandler)handler).HandleTempMessage(miraiSession, e))
									{
										break;
									}
								}
							}
						}
					}
					break;
				case "StrangerMessage":
					{
						var e = StrangerMessageData.Parse(message);
						logger.Info($"[StrangerMessage:{e.Sender.Id}] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IStrangerMessageHandler)
							{
								if (e.MessageChain.Length > 0)
								{
									if (((IStrangerMessageHandler)handler).HandleStrangerMessage(miraiSession, e))
									{
										break;
									}
								}
							}
						}
					}
					break;

				#endregion

				#region 事件

				#region Bot自身事件

				case "BotOnlineEvent":
					{
						var e = BotEventData.Parse(message);
						logger.Info($"[BotOnlineEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotOnlineEventHandler)
							{
								if (((IBotOnlineEventHandler)handler).HandleBotOnlineEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotOfflineEventActive":
					{
						var e = BotEventData.Parse(message);
						logger.Info($"[BotOfflineEventActive] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotOfflineEventActiveHandler)
							{
								if (((IBotOfflineEventActiveHandler)handler).HandleBotOfflineEventActive(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotOfflineEventForce":
					{
						var e = BotEventData.Parse(message);
						logger.Info($"[BotOfflineEventForce] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotOfflineEventForceHandler)
							{
								if (((IBotOfflineEventForceHandler)handler).HandleBotOfflineEventForce(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotOfflineEventDropped":
					{
						var e = BotEventData.Parse(message);
						logger.Info($"[BotOfflineEventDropped] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotOfflineEventDroppedHandler)
							{
								if (((IBotOfflineEventDroppedHandler)handler).HandleBotOfflineEventDropped(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotReloginEvent":
					{
						var e = BotEventData.Parse(message);
						logger.Info($"[BotReloginEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotReloginEventHandler)
							{
								if (((IBotReloginEventHandler)handler).HandleBotReloginEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;

				#endregion

				#region 好友事件

				case "FriendInputStatusChangedEvent":
					{
						var e = FriendInputStatusChangedEventData.Parse(message);
						logger.Info($"[FriendInputStatusChangedEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IFriendInputStatusChangedEventHandler)
							{
								if (((IFriendInputStatusChangedEventHandler)handler).HandleFriendInputStatusChangedEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "FriendNickChangedEvent":
					{
						var e = FriendNickChangedEventData.Parse(message);
						logger.Info($"[FriendNickChangedEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IFriendNickChangedEventHandler)
							{
								if (((IFriendNickChangedEventHandler)handler).HandleFriendNickChangedEventActive(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;

				#endregion

				#region 群事件

				case "BotGroupPermissionChangeEvent":
					{
						var e = BotGroupPermissionChangeEventData.Parse(message);
						logger.Info($"[BotGroupPermissionChangeEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotGroupPermissionChangeEventHandler)
							{
								if (((IBotGroupPermissionChangeEventHandler)handler).HandleBotGroupPermissionChangeEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotMuteEvent":
					{
						var e = BotMuteEventData.Parse(message);
						logger.Info($"[BotMuteEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotMuteEventHandler)
							{
								if (((IBotMuteEventHandler)handler).HandleBotMuteEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotUnmuteEvent":
					{
						var e = BotUnmuteEventData.Parse(message);
						logger.Info($"[BotUnmuteEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotUnmuteEventHandler)
							{
								if (((IBotUnmuteEventHandler)handler).HandleBotUnmuteEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotJoinGroupEvent":
					{
						var e = BotJoinGroupEventData.Parse(message);
						logger.Info($"[BotJoinGroupEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotJoinGroupEventHandler)
							{
								if (((IBotJoinGroupEventHandler)handler).HandleBotJoinGroupEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotLeaveEventActive":
					{
						var e = BotLeaveEventActiveData.Parse(message);
						logger.Info($"[BotLeaveEventActive] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotLeaveEventActiveHandler)
							{
								if (((IBotLeaveEventActiveHandler)handler).HandleBotLeaveEventActive(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotLeaveEventKick":
					{
						var e = BotLeaveEventKickData.Parse(message);
						logger.Info($"[BotLeaveEventKick] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotLeaveEventKickHandler)
							{
								if (((IBotLeaveEventKickHandler)handler).HandleBotLeaveEventKick(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotLeaveEventDisband":
					{
						var e = BotLeaveEventDisbandData.Parse(message);
						logger.Info($"[BotLeaveEventDisband] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotLeaveEventDisbandHandler)
							{
								if (((IBotLeaveEventDisbandHandler)handler).HandleBotLeaveEventDisband(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "GroupRecallEvent":
					{
						var e = GroupRecallEventData.Parse(message);
						logger.Info($"[GroupRecallEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IGroupRecallEventHandler)
							{
								if (((IGroupRecallEventHandler)handler).HandleGroupRecallEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "FriendRecallEvent":
					{
						var e = FriendRecallEventData.Parse(message);
						logger.Info($"[FriendRecallEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IFriendRecallEventHandler)
							{
								if (((IFriendRecallEventHandler)handler).HandleFriendRecallEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "NudgeEvent":
					{
						var e = NudgeEventData.Parse(message);
						logger.Info($"[NudgeEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is INudgeEventHandler)
							{
								if (((INudgeEventHandler)handler).HandleNudgeEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "GroupNameChangeEvent":
					{
						var e = GroupNameChangeEventData.Parse(message);
						logger.Info($"[GroupNameChangeEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IGroupNameChangeEventHandler)
							{
								if (((IGroupNameChangeEventHandler)handler).HandleGroupNameChangeEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "GroupEntranceAnnouncementChangeEvent":
					{
						var e = GroupEntranceAnnouncementChangeEventData.Parse(message);
						logger.Info($"[GroupEntranceAnnouncementChangeEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IGroupEntranceAnnouncementChangeEventHandler)
							{
								if (((IGroupEntranceAnnouncementChangeEventHandler)handler).HandleGroupEntranceAnnouncementChangeEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "GroupMuteAllEvent":
					{
						var e = GroupMuteAllEventData.Parse(message);
						logger.Info($"[GroupMuteAllEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IGroupMuteAllEventHandler)
							{
								if (((IGroupMuteAllEventHandler)handler).HandleGroupMuteAllEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "GroupAllowAnonymousChatEvent":
					{
						var e = GroupAllowAnonymousChatEventData.Parse(message);
						logger.Info($"[GroupAllowAnonymousChatEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IGroupAllowAnonymousChatEventHandler)
							{
								if (((IGroupAllowAnonymousChatEventHandler)handler).HandleGroupAllowAnonymousChatEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "GroupAllowConfessTalkEvent":
					{
						var e = GroupAllowConfessTalkEventData.Parse(message);
						logger.Info($"[GroupAllowConfessTalkEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IGroupAllowConfessTalkEventHandler)
							{
								if (((IGroupAllowConfessTalkEventHandler)handler).HandleGroupAllowConfessTalkEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "GroupAllowMemberInviteEvent":
					{
						var e = GroupAllowMemberInviteEventData.Parse(message);
						logger.Info($"[GroupAllowMemberInviteEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IGroupAllowMemberInviteEventHandler)
							{
								if (((IGroupAllowMemberInviteEventHandler)handler).HandleGroupAllowMemberInviteEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "MemberJoinEvent":
					{
						var e = MemberJoinEventData.Parse(message);
						logger.Info($"[MemberJoinEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IMemberJoinEventHandler)
							{
								if (((IMemberJoinEventHandler)handler).HandleMemberJoinEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "MemberLeaveEventKick":
					{
						var e = MemberLeaveEventKickData.Parse(message);
						logger.Info($"[MemberLeaveEventKick] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IMemberLeaveEventKickHandler)
							{
								if (((IMemberLeaveEventKickHandler)handler).HandleMemberLeaveEventKick(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "MemberLeaveEventQuit":
					{
						var e = MemberLeaveEventQuitData.Parse(message);
						logger.Info($"[MemberLeaveEventQuit] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IMemberLeaveEventQuitHandler)
							{
								if (((IMemberLeaveEventQuitHandler)handler).HandleMemberLeaveEventQuit(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "MemberCardChangeEvent":
					{
						var e = MemberCardChangeEventData.Parse(message);
						logger.Info($"[MemberCardChangeEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IMemberCardChangeEventHandler)
							{
								if (((IMemberCardChangeEventHandler)handler).HandleMemberCardChangeEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "MemberPermissionChangeEvent":
					{
						var e = MemberPermissionChangeEventData.Parse(message);
						logger.Info($"[MemberPermissionChangeEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IMemberPermissionChangeEventHandler)
							{
								if (((IMemberPermissionChangeEventHandler)handler).HandleMemberPermissionChangeEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "MemberMuteEvent":
					{
						var e = MemberMuteEventData.Parse(message);
						logger.Info($"[MemberMuteEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IMemberMuteEventHandler)
							{
								if (((IMemberMuteEventHandler)handler).HandleMemberMuteEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "MemberUnmuteEvent":
					{
						var e = MemberUnmuteEventData.Parse(message);
						logger.Info($"[MemberUnmuteEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IMemberUnmuteEventHandler)
							{
								if (((IMemberUnmuteEventHandler)handler).HandleMemberUnmuteEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;

				#endregion

				#region 申请事件

				case "NewFriendRequestEvent":
					{
						var e = NewFriendRequestEventData.Parse(message);
						logger.Info($"[NewFriendRequestEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is INewFriendRequestEventHandler)
							{
								if (((INewFriendRequestEventHandler)handler).HandleNewFriendRequestEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "MemberJoinRequestEvent":
					{
						var e = MemberJoinRequestEventData.Parse(message);
						logger.Info($"[MemberJoinRequestEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IMemberJoinRequestEventHandler)
							{
								if (((IMemberJoinRequestEventHandler)handler).HandleMemberJoinRequestEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "BotInvitedJoinGroupRequestEvent":
					{
						var e = BotInvitedJoinGroupRequestEventData.Parse(message);
						logger.Info($"[BotInvitedJoinGroupRequestEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IBotInvitedJoinGroupRequestEventHandler)
							{
								if (((IBotInvitedJoinGroupRequestEventHandler)handler).HandleBotInvitedJoinGroupRequestEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;

				#endregion

				#region 其他客户端事件

				case "OtherClientOnlineEvent":
					{
						var e = OtherClientOnlineEventData.Parse(message);
						logger.Info($"[OtherClientOnlineEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IOtherClientOnlineEventHandler)
							{
								if (((IOtherClientOnlineEventHandler)handler).HandleOtherClientOnlineEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				case "OtherClientOfflineEvent":
					{
						var e = OtherClientOfflineEventData.Parse(message);
						logger.Info($"[OtherClientOfflineEvent] => {message.ToString(Formatting.None).ReplaceReturn()}");
						foreach (var handler in handlers)
						{
							if (handler is IOtherClientOfflineEventHandler)
							{
								if (((IOtherClientOfflineEventHandler)handler).HandleOtherClientOfflineEvent(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;

				#endregion

				#endregion

				default:
					logger.Warning($"[Unsupported] => {message.ToString(Formatting.None).ReplaceReturn()}");
					break;
			}
		}
	}
}
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
#pragma warning restore CS8602 // 解引用可能出现空引用。
#pragma warning restore CS8604 // 引用类型参数可能为 null。
#pragma warning restore IDE0038 // 使用模式匹配