using Mirai.CSharp.Light.Exception;
using Mirai.CSharp.Light.Models;
using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Models.EventArgs;
using Mirai.CSharp.Light.Models.Message;
using Newtonsoft.Json.Linq;
using System;
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
		#region 类成员变量、属性定义

		public string SessionKey { get; set; } = "";

		public BasicData BotData_ = new();

		public IBasicData BotData { get => BotData_; }

		/// <summary>
		/// 使用Mirai-Api-Http的HTTP Adapter
		/// </summary>
		public HttpClient? httpClient;

		public Version APIVersion { get; set; } = new Version();

		#endregion

		#region 辅助函数

		/// <summary>
		/// 检查返回结果，有错误就抛出异常
		/// </summary>
		/// <param name="result">Json结果</param>
		/// <returns>Json结果</returns>
		/// <exception cref="MiraiException"></exception>
		private static JObject CheckResult(JObject result)
		{
			var code = (int)result["code"];
			if (code > 0)
			{
				if (result.ContainsKey("msg"))
				{
					throw new MiraiException(code, (string)result["msg"]);
				}
				else
				{
					throw new MiraiException(code);
				}
			}
			return result;
		}

		private static void CheckResponse(HttpResponseMessage msg)
		{
			if (msg.StatusCode != HttpStatusCode.OK)
			{
				var text = $"HTTP错误({(int)msg.StatusCode})：{msg.ReasonPhrase}";
				throw new System.Exception(text);
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
			return (int)result["messageId"];
		}

		public Task<int> SendGroupMessageAsync(long target, IChatMessage[] messageChain, int? quote = null) => Task.Run(() => SendGroupMessage(target, messageChain, quote));

		#endregion

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
			return (int)result["messageId"];
		}

		public Task<int> SendFriendMessageAsync(long target, IChatMessage[] messageChain, int? quote = null) => Task.Run(() => SendFriendMessage(target, messageChain, quote));

		#endregion

		#region 发送临时消息

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
			return (int)result["messageId"];
		}

		public Task<int> SendTempMessageAsync(long qq, long group, IChatMessage[] messageChain, int? quote = null) => Task.Run(() => SendTempMessage(qq, group, messageChain, quote));

		#endregion

		#region 撤回消息

		public void RevokeMessage(int messageId, long target)
		{
			if (APIVersion < Version.Parse("2.6.0"))
			{
				throw new System.Exception("API版本为2.6.0以下，请使用void RevokeMessage(int messageId)");
			}
			Post("recall", new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = messageId,
			});
		}

		public Task RevokeMessageAsync(int messageId, long target) => Task.Run(() =>
		{
			if (APIVersion < Version.Parse("2.6.0"))
			{
				throw new System.Exception("API版本为2.6.0以下，请使用Task RevokeMessageAsync(int messageId)");
			}
			RevokeMessage(messageId, target);
		});

		public void RevokeMessage(int messageId)
		{
			if (APIVersion >= Version.Parse("2.6.0"))
			{
				throw new System.Exception("API版本为2.6.0及以上，请使用void RevokeMessage(int messageId, long target)");
			}
			Post("recall", new JObject()
			{
				["sessionKey"] = SessionKey,
				["target"] = messageId,
			});
		}

		public Task RevokeMessageAsync(int messageId) => Task.Run(() =>
		{
			if (APIVersion >= Version.Parse("2.6.0"))
			{
				throw new System.Exception("API版本为2.6.0及以上，请使用Task RevokeMessageAsync(int messageId, long target)");
			}
			RevokeMessage(messageId);
		});

		#endregion

		#region 文件上传

		public ImageMessage UploadImage(UploadType type, string path)
		{
			var result = Post("uploadImage", new MultipartFormDataContent
			{
				{ new StringContent(SessionKey), "sessionKey" },
				{ new StringContent(type.GetString()), "type" },
				{ new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read)), "img" }
			});
			return new ImageMessage((string)result["imageId"], (string)result["url"], null, null);
		}

		public Task<ImageMessage> UploadImageAsync(UploadType type, string path) => Task.Run(() => UploadImage(type, path));

		#endregion

		#region 通过消息ID获取消息

		public IMessageEventArgs GetMessage(int id, long target)
		{
			if (APIVersion < Version.Parse("2.6.0"))
			{
				throw new System.Exception("API版本为2.6.0以下，请使用IMessageEventArgs GetMessage(int messageId)");
			}
			var result = Get("messageFromId", new JObject()
			{
				["sessionKey"] = SessionKey,
				["id"] = id,
				["target"] = target,
			});
			return MessageEventArgs.ParseAuto((JObject)result["data"]);
		}

		public Task<IMessageEventArgs> GetMessageAsync(int id, long target) => Task.Run(() =>
		{
			if (APIVersion < Version.Parse("2.6.0"))
			{
				throw new System.Exception("API版本为2.6.0以下，请使用Task<IMessageEventArgs> GetMessageAsync(int messageId)");
			}
			return GetMessage(id, target);
		});

		public IMessageEventArgs GetMessage(int messageId)
		{
			if (APIVersion >= Version.Parse("2.6.0"))
			{
				throw new System.Exception("API版本为2.6.0及以上，请使用IMessageEventArgs GetMessage(int id, long target)");
			}
			var result = Get("messageFromId", new JObject()
			{
				["sessionKey"] = SessionKey,
				["id"] = messageId,
			});
			return MessageEventArgs.ParseAuto((JObject)result["data"]);
		}

		public Task<IMessageEventArgs> GetMessageAsync(int messageId) => Task.Run(() =>
		{
			if (APIVersion >= Version.Parse("2.6.0"))
			{
				throw new System.Exception("API版本为2.6.0及以上，请使用Task<IMessageEventArgs> GetMessageAsync(int id, long target)");
			}
			return GetMessage(messageId);
		});

		#endregion
	}
}
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
#pragma warning restore CS8602 // 解引用可能出现空引用。
#pragma warning restore CS8604 // 引用类型参数可能为 null。
