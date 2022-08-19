using Mirai.CSharp.Light.Exception;
using Mirai.CSharp.Light.Extensions;
using Mirai.CSharp.Light.Logger;
using Mirai.CSharp.Light.Models;
using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Models.Message;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning disable CS8601 // 引用类型赋值可能为 null。
#pragma warning disable CS8602 // 解引用可能出现空引用。
#pragma warning disable CS8604 // 引用类型参数可能为 null。
namespace Mirai.CSharp.Light.Session
{
	internal class MiraiSession : IMiraiSession
	{
		#region 其它成员

		public string SessionKey { get; set; } = "";

		public UserData BotData_ = new();

		public IUserData BotData { get => BotData_; }

		/// <summary>
		/// 使用Mirai-Api-Http的HTTP Adapter
		/// </summary>
		public HttpClient? httpClient;

		public Version APIVersion { get; set; } = new Version();

		private readonly MiraiCSharpLightLogger logger = MiraiCSharpLightLogger.GetLogger("MiraiSession");

		#region 辅助函数

		/// <summary>
		/// 检查返回结果，有错误就抛出异常
		/// </summary>
		/// <param name="result">Json结果</param>
		/// <returns>Json结果</returns>
		/// <exception cref="MiraiException"></exception>
		private static JObject CheckResult(JObject result)
		{
			if (result.ContainsKey("code"))
			{
				var code = (int)result["code"];
				if (code > 0)
				{
					if (result.ContainsKey("msg"))
					{
						throw new MiraiException("MiraiSession", $"API返回结果不为零[{code}]", code, (string)result["msg"]);
					}
					else
					{
						throw new MiraiException("MiraiSession", $"API返回结果不为零[{code}]", code);
					}
				}
			}
			return result;
		}

		private static void CheckResponse(HttpResponseMessage msg)
		{
			if (msg.StatusCode != HttpStatusCode.OK)
			{
				var text = $"HTTP错误({(int)msg.StatusCode})：{msg.ReasonPhrase}";
				throw new MiraiException("MiraiSession", text);
			}
		}

		#endregion

		#region Post与Get

		public JObject Post(string uri, JObject form)
		{
			var task1 = httpClient.PostAsync(uri, new StringContent(form.ToString()));
			task1.Wait();
			CheckResponse(task1.Result);
			var task2 = task1.Result.Content.ReadAsStringAsync();
			task2.Wait();
			return CheckResult(JObject.Parse(task2.Result));
		}

		public JObject Post(string uri, MultipartFormDataContent form)
		{
			var task1 = httpClient.PostAsync(uri, form);
			task1.Wait();
			CheckResponse(task1.Result);
			var task2 = task1.Result.Content.ReadAsStringAsync();
			task2.Wait();
			return CheckResult(JObject.Parse(task2.Result));
		}

		public JObject Get(string uri)
		{
			var task1 = httpClient.GetAsync(uri);
			task1.Wait();
			CheckResponse(task1.Result);
			var task2 = task1.Result.Content.ReadAsStringAsync();
			return CheckResult(JObject.Parse(task2.Result));
		}

		public JObject Get(string uri, JObject param)
		{
			var sb = new StringBuilder();
			sb.Append(uri);
			sb.Append("?");
			bool first = true;
			foreach (var item in param)
			{
				if (first)
				{
					first = false;
				}
				else
				{
					sb.Append("&");
				}
				sb.Append($"{item.Key}={HttpUtility.UrlEncode(item.Value.ToString())}");
			}
			var task1 = httpClient.GetAsync(sb.ToString());
			task1.Wait();
			CheckResponse(task1.Result);
			var task2 = task1.Result.Content.ReadAsStringAsync();
			return CheckResult(JObject.Parse(task2.Result));
		}

		#endregion

		#endregion

		#region 接口

		#region 缓存操作

		#region 通过messageId获取消息

		public CommonMessageData GetMessage(int id, long target)
		{
			if (APIVersion < new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0以下，请使用IMessageData GetMessage(int messageId)");
			}
			var result = Get("messageFromId", new JObject()
			{
				["sessionKey"] = SessionKey,
				["id"] = id,
				["target"] = target,
			});
			logger.Info($"[GetMessage:id={id},target={target}] => {result.ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()}");
			return CommonMessageData.Parse((JObject)result["data"]);
		}

		public Task<CommonMessageData> GetMessageAsync(int id, long target) => Task.Run(() =>
		{
			if (APIVersion < new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0以下，请使用Task<IMessageData> GetMessageAsync(int messageId)");
			}
			return GetMessage(id, target);
		});

		public CommonMessageData GetMessage(int messageId)
		{
			if (APIVersion >= new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0及以上，请使用IMessageData GetMessage(int id, long target)");
			}
			var result = Get("messageFromId", new JObject()
			{
				["sessionKey"] = SessionKey,
				["id"] = messageId,
			});
			logger.Info($"[GetMessage:messageId={messageId}] => {result.ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()}");
			return CommonMessageData.Parse((JObject)result["data"]);
		}

		public Task<CommonMessageData> GetMessageAsync(int messageId) => Task.Run(() =>
		{
			if (APIVersion >= new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0及以上，请使用Task<IMessageData> GetMessageAsync(int id, long target)");
			}
			return GetMessage(messageId);
		});

		#endregion

		#endregion

		#region 获取账号信息

		#region 获取好友列表

		public IUserData[] GetFriendList()
		{
			var result = Get("friendList", new JObject()
			{
				["sessionKey"] = SessionKey,
			});
			var count = ((JArray)result["data"]).Count;
			var array = new IUserData[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = UserData.Parse((JObject)result["data"][i]);
			}
			logger.Debug($"[GetFriendList] => {result.ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()}");
			return array;
		}

		public Task<IUserData[]> GetFriendListAsync() => Task.Run(() => GetFriendList());

		#endregion

		#region 获取群列表

		public IGroupData[] GetGroupList()
		{
			var result = Get("groupList", new JObject()
			{
				["sessionKey"] = SessionKey,
			});
			var count = ((JArray)result["data"]).Count;
			var array = new IGroupData[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = GroupData.Parse((JObject)result["data"][i]);
			}
			logger.Debug($"[GetGroupList] => {result.ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()}");
			return array;
		}

		public Task<IGroupData[]> GetGroupListAsync() => Task.Run(() => GetGroupList());

		#endregion

		#region 获取群成员列表

		public IGroupMemberData[] GetGroupMemberList(long target)
		{
			var result = Get("memberList", new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = target,
			});
			var count = ((JArray)result["data"]).Count;
			var array = new IGroupMemberData[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = GroupMemberData.Parse((JObject)result["data"][i]);
			}
			logger.Debug($"[GetGroupMemberList] => {result.ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()}");
			return array;
		}

		public Task<IGroupMemberData[]> GetGroupMemberListAsync(long target) => Task.Run(() => GetGroupMemberList(target));

		#endregion

		#region 获取Bot资料

		public IUserProfileData GetBotProfile()
		{
			var result = Get("botProfile", new JObject()
			{
				["sessionKey"] = SessionKey,
			});
			logger.Info($"[GetBotProfile] => {result.ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()}");
			return UserProfileData.Parse(result);
		}

		public Task<IUserProfileData> GetBotProfileAsync() => Task.Run(() => GetBotProfile());

		#endregion

		#region 获取好友资料

		public IUserProfileData GetFriendProfile(long target)
		{
			var result = Get("friendProfile", new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = target,
			});
			logger.Info($"[GetFriendProfile:target={target}] => {result.ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()}");
			return UserProfileData.Parse(result);
		}

		public Task<IUserProfileData> GetFriendProfileAsync(long target) => Task.Run(() => GetFriendProfile(target));

		#endregion

		#region 获取群成员资料

		public IUserProfileData GetGroupMemberProfile(long target, long memberId)
		{
			var result = Get("memberProfile", new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = target,
				["memberId"] = memberId,
			});
			logger.Info($"[GetGroupMemberProfile:target={target},memberId={memberId}] => {result.ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()}");
			return UserProfileData.Parse(result);
		}

		public Task<IUserProfileData> GetGroupMemberProfileAsync(long target, long memberId) => Task.Run(() => GetGroupMemberProfile(target, memberId));

		#endregion

		#region 获取QQ用户资料

		public IUserProfileData GetUserProfile(long target)
		{
			if (APIVersion < new Version(2, 5, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.5.0以下，不支持获取QQ用户资料");
			}
			var result = Get("userProfile", new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = target,
			});
			logger.Info($"[GetUserProfile:target={target}] => {result.ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()}");
			return UserProfileData.Parse(result);
		}

		public Task<IUserProfileData> GetUserProfileAsync(long target)
		{
			if (APIVersion < new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.5.0以下，不支持获取QQ用户资料");
			}
			return Task.Run(() => GetUserProfileAsync(target));
		}

		#endregion

		#endregion

		#region 消息发送与撤回

		#region 发送好友消息

		public int SendFriendMessage(long target, IChatMessage[] messageChain, int? quote = null)
		{
			var form = new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = target,
				["messageChain"] = messageChain.ToJArray(),
			};
			if (quote != null)
			{
				form["quote"] = quote;
			}
			var result = Post("sendFriendMessage", form);
			logger.Info($"[SendFriendMessage] <= target={target},messageChain={messageChain.ToJArray().ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()},quote={quote}");
			return (int)result["messageId"];
		}

		public Task<int> SendFriendMessageAsync(long target, IChatMessage[] messageChain, int? quote = null) => Task.Run(() => SendFriendMessage(target, messageChain, quote));

		#endregion

		#region 发送群消息

		public int SendGroupMessage(long target, IChatMessage[] messageChain, int? quote = null)
		{
			var form = new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = target,
				["messageChain"] = messageChain.ToJArray(),
			};
			if (quote != null)
			{
				form["quote"] = quote;
			}
			var result = Post("sendGroupMessage", form);
			logger.Info($"[SendGroupMessage] <= target={target},messageChain={messageChain.ToJArray().ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()},quote={quote}");
			return (int)result["messageId"];
		}

		public Task<int> SendGroupMessageAsync(long target, IChatMessage[] messageChain, int? quote = null) => Task.Run(() => SendGroupMessage(target, messageChain, quote));

		#endregion

		#region 发送临时会话消息

		public int SendTempMessage(long qq, long group, IChatMessage[] messageChain, int? quote = null)
		{
			var form = new JObject()
			{
				["sessionKey"] = SessionKey,
				["qq"] = qq,
				["group"] = group,
				["messageChain"] = messageChain.ToJArray(),
			};
			if (quote != null)
			{
				form["quote"] = quote;
			}
			var result = Post("sendTempMessage", form);
			logger.Info($"[SendTempMessage] <= qq={qq},group={group},messageChain={messageChain.ToJArray().ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()},quote={quote}");
			return (int)result["messageId"];
		}

		public Task<int> SendTempMessageAsync(long qq, long group, IChatMessage[] messageChain, int? quote = null) => Task.Run(() => SendTempMessage(qq, group, messageChain, quote));

		#endregion

		#region 发送头像戳一戳消息

		public void SendNudge(long target, long subject, ContextType kind)
		{
			var form = new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = target,
				["subject"] = subject,
				["kind"] = kind.GetString(),
			};
			Post("sendTempMessage", form);
			logger.Info($"[SendNudge] <= target={target},subject={subject},kind={kind.GetString()}");
		}

		public Task SendNudgeAsync(long target, long subject, ContextType kind) => Task.Run(() => SendNudge(target, subject, kind));

		#endregion

		#region 撤回消息

		public void RevokeMessage(int messageId, long target)
		{
			if (APIVersion < new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0以下，请使用void RevokeMessage(int messageId)");
			}
			Post("recall", new JObject()
			{
				["sessionKey"] = SessionKey,
				["messageId"] = messageId,
				["target"] = target,
			});
			logger.Info($"[RevokeMessage] <= messageId={messageId},target={target}");
		}

		public Task RevokeMessageAsync(int messageId, long target) => Task.Run(() =>
		{
			if (APIVersion < new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0以下，请使用Task RevokeMessageAsync(int messageId)");
			}
			RevokeMessage(messageId, target);
		});

		public void RevokeMessage(int messageId)
		{
			if (APIVersion >= new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0及以上，请使用void RevokeMessage(int messageId, long target)");
			}
			Post("recall", new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = messageId,
			});
			logger.Info($"[RevokeMessage] <= target={messageId}");
		}

		public Task RevokeMessageAsync(int messageId) => Task.Run(() =>
		{
			if (APIVersion >= new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0及以上，请使用Task RevokeMessageAsync(int messageId, long target)");
			}
			RevokeMessage(messageId);
		});

		#endregion

		#region 获取漫游消息

		public CommonMessageData[] GetRoamingMessages(long timeStart, long timeEnd, long target)
		{
			if (APIVersion < new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0以下，不支持获取漫游消息");
			}
			var form = new JObject()
			{
				//["sessionKey"] = SessionKey,
				["timeStart"] = timeStart,
				["timeEnd"] = timeEnd,
				["target"] = target,
			};
			var result = Post("roamingMessages", form);
			logger.Info($"[GetRoamingMessages:timeStart={timeStart},timeEnd={timeEnd},target={target}] => {result.ToString(Newtonsoft.Json.Formatting.None).ReplaceReturn()}");
			JArray array = (JArray)result["data"];
			var data = new CommonMessageData[array.Count];
			for (int i = 0; i < array.Count; i++)
			{
				data[i] = CommonMessageData.Parse((JObject)array[i]);
			}
			return data;
		}

		public Task<CommonMessageData[]> GetRoamingMessagesAsync(long timeStart, long timeEnd, long target)
		{
			if (APIVersion < new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0以下，不支持获取漫游消息");
			}
			return Task.Run(() => GetRoamingMessages(timeStart, timeEnd, target));
		}

		public CommonMessageData[] GetRoamingMessages(DateTime timeStart, DateTime timeEnd, long target)
		{
			if (APIVersion < new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0以下，不支持获取漫游消息");
			}
			return GetRoamingMessages(timeStart.ToTimestamp(), timeEnd.ToTimestamp(), target);
		}

		public Task<CommonMessageData[]> GetRoamingMessagesAsync(DateTime timeStart, DateTime timeEnd, long target) {
			if (APIVersion < new Version(2, 6, 0))
			{
				throw new MiraiException("MiraiSession", "API版本为2.6.0以下，不支持获取漫游消息");
			}
			return GetRoamingMessagesAsync(timeStart.ToTimestamp(), timeEnd.ToTimestamp(), target);
		}

		#endregion

		#endregion

		#region 账号管理

		#region 删除好友

		public void DeleteFriend(long target)
		{
			Post("deleteFriend", new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = target,
			});
			logger.Info($"[DeleteFriend] <= target={target}");
		}

		public Task DeleteFriendAsync(long target) => Task.Run(() => DeleteFriend(target));

		#endregion

		#endregion

		#region 多媒体内容上传

		#region 图片文件上传

		public ImageMessage UploadImage(ContextType type, string path)
		{
			var result = Post("uploadImage", new MultipartFormDataContent
			{
				{ new StringContent(SessionKey), "sessionKey" },
				{ new StringContent(type.GetString()), "type" },
				{ new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read)), "img" }
			});
			logger.Info($"[UploadImage] <= ImageId:{(string)result["imageId"]}");
			return new ImageMessage((string)result["imageId"], (string)result["url"], null, null);
		}

		public Task<ImageMessage> UploadImageAsync(ContextType type, string path) => Task.Run(() => UploadImage(type, path));

		#endregion

		#endregion

		#endregion
	}
}
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
#pragma warning restore CS8602 // 解引用可能出现空引用。
#pragma warning restore CS8604 // 引用类型参数可能为 null。
