using Mirai.CSharp.Light.Exception;
using Mirai.CSharp.Light.Handler;
using Mirai.CSharp.Light.Logger;
using Mirai.CSharp.Light.Models.EventArgs;
using Mirai.CSharp.Light.Session;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Web;

#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning disable CS8601 // 引用类型赋值可能为 null。
#pragma warning disable CS8602 // 解引用可能出现空引用。
#pragma warning disable CS8604 // 引用类型参数可能为 null。
namespace Mirai.CSharp.Light
{
	/// <summary>
	/// MiraiLight类，使用HTTP Adapter
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

		private MiraiCSharpLightLogger logger = MiraiCSharpLightLogger.GetLogger("MiraiCSharpLight");

		/// <summary>
		/// 连接到Mirai-Api-Http，连接即视为开始运行
		/// </summary>
		/// <param name="url">Mirai-Api-Http服务的URL，例如"http://0.0.0.0:12345"</param>
		/// <exception cref="System.Exception"></exception>
		/// <exception cref="MiraiException"></exception>
		public void Connect(string url)
		{
			if (QQ == 0)
			{
				throw new System.Exception("未设置Bot的QQ号");
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
			try
			{
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
				miraiSession.BotData_.Id = (long)result["data"]["qq"]["id"];
				miraiSession.BotData_.NickName = (string)result["data"]["qq"]["nickname"];
				miraiSession.BotData_.Remark = (string)result["data"]["qq"]["remark"];
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
			catch (System.Exception ex)
			{
				logger.Error("Mirai.CSharp.Light.MiraiCSharpLight.Connect执行异常");
				logger.Error(ex.ToString());
			}
		}

		/// <summary>
		/// 异步连接到Mirai-Api-Http，连接即视为开始运行
		/// </summary>
		/// <param name="url">Mirai-Api-Http服务的URL，例如"http://0.0.0.0:12345"</param>
		/// <exception cref="System.Exception"></exception>
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
		/// <exception cref="System.Exception"></exception>
		/// <exception cref="MiraiException"></exception>
		public void Release()
		{
			try
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
			catch (System.Exception ex)
			{
				logger.Error("Mirai.CSharp.Light.MiraiCSharpLight.Release执行异常");
				logger.Error(ex.ToString());
			}
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
				try
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
				catch (System.Exception ex)
				{
					logger.Error("Mirai.CSharp.Light.MiraiCSharpLight.MessageLoopFunc执行异常");
					logger.Error(ex.ToString());
				}
			}
		}

		private void HandleMessage(JObject message)
		{
			var type = (string)message["type"];
			switch (type)
			{
				case "GroupMessage":
					foreach (var handler in handlers)
					{
						if (handler is IGroupMessageHandler)
						{
							var e = GroupMessageEventArgs.Parse(message);
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
					break;
				case "FriendMessage":
					foreach (var handler in handlers)
					{
						if (handler is IFriendMessageHandler)
						{
							var e = FriendMessageEventArgs.Parse(message);
							if (e.MessageChain.Length > 0)
							{
								if (((IFriendMessageHandler)handler).HandleFriendMessage(miraiSession, e))
								{
									break;
								}
							}
						}
					}
					break;
				default:
					break;
			}
		}
	}
}
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
#pragma warning restore CS8602 // 解引用可能出现空引用。
#pragma warning restore CS8604 // 引用类型参数可能为 null。