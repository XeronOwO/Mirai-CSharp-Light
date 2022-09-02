using Mirai.CSharp.Light.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 转发消息
	/// </summary>
	public class NodeMessage
	{
		/// <summary>
		/// NodeMessage构造函数
		/// </summary>
		public NodeMessage()
		{
			SenderName = "";
			MessageChain = Array.Empty<IChatMessage>();
		}

		/// <summary>
		/// NodeMessage构造函数
		/// </summary>
		/// <param name="senderId">发送人QQ号</param>
		/// <param name="time">发送时间</param>
		/// <param name="senderName">显示名称</param>
		/// <param name="messageChain">消息数组</param>
		/// <param name="messageId">可以只使用消息messageId，从缓存中读取一条消息作为节点</param>
		public NodeMessage(long senderId, int time, string senderName, IChatMessage[] messageChain, int? messageId = null)
		{
			SenderId = senderId;
			Time = time;
			SenderName = senderName;
			MessageChain = messageChain;
			MessageId = messageId;
		}

		/// <summary>
		/// 源数据
		/// </summary>
		public JObject ToJObject()
		{
			return new JObject()
			{
				["senderId"] = SenderId,
				["time"] = Time,
				["senderName"] = SenderName,
				["messageChain"] = MessageChain.ToJArray(),
				["messageId"] = MessageId,
			};
		}

		/// <summary>
		/// 发送人QQ号
		/// </summary>
		public long SenderId { get; set; }

		/// <summary>
		/// 发送时间
		/// </summary>
		public int Time { get; set; }

		/// <summary>
		/// 显示名称
		/// </summary>
		public string SenderName { get; set; }

		/// <summary>
		/// 消息数组
		/// </summary>
		public IChatMessage[] MessageChain { get; set; }

		/// <summary>
		/// 可以只使用消息messageId，从缓存中读取一条消息作为节点
		/// </summary>
		public int? MessageId { get; set; }
	}
}
