using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Models.Message;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning disable CS8601 // 引用类型赋值可能为 null。
#pragma warning disable CS8602 // 解引用可能出现空引用。
#pragma warning disable CS8604 // 引用类型参数可能为 null。
namespace Mirai.CSharp.Light.Extensions
{
	/// <summary>
	/// 通用消息信息
	/// </summary>
	public class CommonMessageData
	{
		private string type = "";

		/// <summary>
		/// 消息类型
		/// </summary>
		[JsonIgnore]
		public string Type => type;

		private ISenderData sender = new SenderData();

		/// <summary>
		/// 发送者信息
		/// </summary>
		[JsonIgnore]
		public ISenderData Sender => sender;

		[JsonIgnore]
		private IChatMessage[] messageChain = Array.Empty<IChatMessage>();

		/// <summary>
		/// 消息链
		/// </summary>
		[JsonIgnore]
		public IChatMessage[] MessageChain => messageChain;

		/// <summary>
		/// 解析消息
		/// </summary>
		/// <param name="message">Json消息</param>
		/// <returns>解析的消息</returns>
		public static CommonMessageData Parse(JObject message)
		{
			var data = new CommonMessageData
			{
				type = (string)message["type"],
				messageChain = ((JArray)message["messageChain"]).ToIChatMessageArray(),
			};
			switch (data.Type)
			{
				case "GroupMessage":
					data.sender = JsonConvert.DeserializeObject<GroupMessageData>(message.ToString(Formatting.None)).sender;
					break;
				case "FriendMessage":
					data.sender = JsonConvert.DeserializeObject<FriendMessageData>(message.ToString(Formatting.None)).sender;
					break;
				case "TempMessage":
					data.sender = JsonConvert.DeserializeObject<TempMessageData>(message.ToString(Formatting.None)).sender;
					break;
				case "StrangerMessage":
					data.sender = JsonConvert.DeserializeObject<StrangerMessageData>(message.ToString(Formatting.None)).sender;
					break;
				default:
					break;
			}
			return data;
		}

		/// <summary>
		/// 作为群消息信息获取
		/// </summary>
		/// <returns>群消息信息</returns>
		public IGroupMessageData GetAsGroupMessageData()
		{
			return new GroupMessageData()
			{
				type = type,
				sender = (GroupMemberData)sender,
				messageChain = messageChain,
			};
		}

		/// <summary>
		/// 作为好友消息信息获取
		/// </summary>
		/// <returns>群消息信息</returns>
		public IFriendMessageData GetAsFriendMessageData()
		{
			return new FriendMessageData()
			{
				type = type,
				sender = (UserData)sender,
				messageChain = messageChain,
			};
		}

		/// <summary>
		/// 作为临时消息信息获取
		/// </summary>
		/// <returns>群消息信息</returns>
		public ITempMessageData GetAsTempMessageData()
		{
			return new TempMessageData()
			{
				type = type,
				sender = (TempSenderData)sender,
				messageChain = messageChain,
			};
		}

		/// <summary>
		/// 作为陌生人消息信息获取
		/// </summary>
		/// <returns>群消息信息</returns>
		public IStrangerMessageData GetAsStrangerMessageData()
		{
			return new StrangerMessageData()
			{
				type = type,
				sender = (UserData)sender,
				messageChain = messageChain,
			};
		}
	}
}
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
#pragma warning restore CS8602 // 解引用可能出现空引用。
#pragma warning restore CS8604 // 引用类型参数可能为 null。
