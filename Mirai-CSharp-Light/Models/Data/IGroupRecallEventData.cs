using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 群消息撤回
	/// </summary>
	public interface IGroupRecallEventData
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
		/// Bot被踢出的群的信息
		/// </summary>
		public IGroupData Group { get; }

		/// <summary>
		/// Bot被踢后获取操作人的 Member 对象
		/// </summary>
		public IGroupMemberData Operator { get; }
	}
}
