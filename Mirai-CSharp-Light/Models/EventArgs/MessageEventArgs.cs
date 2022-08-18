using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Models.Message;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning disable CS8601 // 引用类型赋值可能为 null。
#pragma warning disable CS8602 // 解引用可能出现空引用。
#pragma warning disable CS8604 // 引用类型参数可能为 null。
namespace Mirai.CSharp.Light.Models.EventArgs
{
    internal abstract class MessageEventArgs : IMessageEventArgs
	{
		public abstract string Type { get; set; }

		public abstract IMessageSenderData Sender { get; }

		public abstract IChatMessage[] MessageChain { get; set; }

		public static DateTime GetDateTimeFromUnixTimeStamp(long timeStamp)
		{
			DateTime dtStart = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1, 0, 0, 0), TimeZoneInfo.Local);
			long lTime = timeStamp * 10000000;
			TimeSpan toNow = new(lTime);
			DateTime targetDt = dtStart.Add(toNow);
			return targetDt;
		}

		public static void ParseType(MessageEventArgs e, JObject json)
		{
			e.Type = (string)json["type"];
		}

		public static void ParseMessageChain(MessageEventArgs e, JObject json)
		{
			var chain = (JArray)json["messageChain"];
			e.MessageChain = new IChatMessage[chain.Count];
			for (int i = 0; i < chain.Count; i++)
			{
				var data = (JObject)chain[i];
				switch ((string)data["type"])
				{
					case "Source":
						e.MessageChain[i] = new SourceMessage()
						{
							Id = (int)data["id"],
							Time = (long)data["time"],
						};
						break;
					case "Plain":
						e.MessageChain[i] = new PlainMessage((string)data["text"]);
						break;
					case "At":
						e.MessageChain[i] = new AtMessage((long)data["target"]);
						break;
					case "AtAll":
						e.MessageChain[i] = new AtAllMessage()
						{
							Target = (long)data["target"],
						};
						break;
					case "Face":
						e.MessageChain[i] = new FaceMessage((long?)data["faceId"], (string?)data["name"]);
						break;
					case "Image":
						e.MessageChain[i] = new ImageMessage((string?)data["ImageId"], (string?)data["url"], (string?)data["path"], (string?)data["base64"]);
						break;
					case "FlashImage":
						e.MessageChain[i] = new FlashImageMessage((string?)data["ImageId"], (string?)data["url"], (string?)data["path"], (string?)data["base64"]);
						break;
					case "Voice":
						e.MessageChain[i] = new VoiceMessage((string?)data["VoiceId"], (string?)data["url"], (string?)data["path"], (string?)data["base64"], (string?)data["length"]);
						break;
					case "Xml":
						e.MessageChain[i] = new XmlMessage((string?)data["xml"]);
						break;
					default:
						break;
				}
			}
		}

		public static IMessageEventArgs ParseAuto(JObject json)
		{
			return (string)json["type"] switch
			{
				"FriendMessage" => FriendMessageEventArgs.Parse(json),
				"GroupMessage" => GroupMessageEventArgs.Parse(json),
				"TempMessage" => TempMessageEventArgs.Parse(json),
				_ => throw new System.Exception("暂时不支持解析的消息类型"),
			};
		}
	}
}
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
#pragma warning restore CS8602 // 解引用可能出现空引用。
#pragma warning restore CS8604 // 引用类型参数可能为 null。
