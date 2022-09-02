using Mirai.CSharp.Light.Models.Message;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning disable CS8601 // 引用类型赋值可能为 null。
#pragma warning disable CS8604 // 引用类型参数可能为 null。
namespace Mirai.CSharp.Light.Extensions
{
	internal static class JArrayExtension
	{
		public static IChatMessage[] ToIChatMessageArray(this JArray array)
		{
			var chain = new IChatMessage[array.Count];
			for (int i = 0; i < array.Count; i++)
			{
				var data = array[i];
				switch ((string)data["type"])
				{
					case "Source":
						chain[i] = new SourceMessage()
						{
							Id = (int)data["id"],
							Time = (long)data["time"],
						};
						break;
					case "Plain":
						chain[i] = new PlainMessage((string)data["text"]);
						break;
					case "Quote":
						chain[i] = new QuoteMessage((int)data["id"], (long)data["groupId"], (long)data["senderId"], (long)data["targetId"], ((JArray)data["origin"]).ToIChatMessageArray());
						break;
					case "At":
						chain[i] = new AtMessage((long)data["target"]);
						break;
					case "AtAll":
						chain[i] = new AtAllMessage()
						{
							Target = (long)data["target"],
						};
						break;
					case "Face":
						chain[i] = new FaceMessage((long?)data["faceId"], (string?)data["name"]);
						break;
					case "Image":
						chain[i] = new ImageMessage((string?)data["imageId"], (string?)data["url"], (string?)data["path"], (string?)data["base64"]);
						break;
					case "FlashImage":
						chain[i] = new FlashImageMessage((string?)data["imageId"], (string?)data["url"], (string?)data["path"], (string?)data["base64"]);
						break;
					case "Voice":
						chain[i] = new VoiceMessage((string?)data["VoiceId"], (string?)data["url"], (string?)data["path"], (string?)data["base64"], (string?)data["length"]);
						break;
					case "Xml":
						chain[i] = new XmlMessage((string?)data["xml"]);
						break;
					case "Forward":
						chain[i] = new ForwardMessage(((JArray)data["nodeList"]).ToNodeMessageArray());
						break;
					default:
						break;
				}
			}
			return chain;
		}

		public static NodeMessage[] ToNodeMessageArray(this JArray array)
		{
			var list = new List<NodeMessage>();
			foreach (var obj in array.Cast<JObject>())
			{
				list.Add(new NodeMessage()
				{
					SenderId = (long)obj["senderId"],
					Time = (int)obj["time"],
					SenderName = (string)obj["senderName"],
					MessageChain = ((JArray)obj["messageChain"]).ToIChatMessageArray(),
					MessageId = (int?)obj["messageId"],
				});
			}
			return list.ToArray();
		}
	}
}
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
#pragma warning restore CS8604 // 引用类型参数可能为 null。
