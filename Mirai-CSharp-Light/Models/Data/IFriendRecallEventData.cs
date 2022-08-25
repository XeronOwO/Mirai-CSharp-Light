using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 好友消息撤回
	/// </summary>
	public interface IFriendRecallEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 原消息发送者的QQ号
		/// </summary>
		public long AuthorId { get; }

		/// <summary>
		/// 原消息messageId
		/// </summary>
		public int MessageId { get; }

		/// <summary>
		/// 原消息发送时间
		/// </summary>
		public int Time { get; }

		/// <summary>
		/// 好友QQ号或BotQQ号
		/// </summary>
		public long Operator { get; }
	}
}
