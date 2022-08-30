using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// Bot被邀请入群申请事件信息
	/// </summary>
	public interface IBotInvitedJoinGroupRequestEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 事件标识，响应该事件时的标识
		/// </summary>
		public long EventId { get; }

		/// <summary>
		/// 邀请人（好友）的QQ号
		/// </summary>
		public long FromId { get; }

		/// <summary>
		/// 被邀请进入群的群号
		/// </summary>
		public long GroupId { get; }

		/// <summary>
		/// 被邀请进入群的群名称
		/// </summary>
		public string GroupName { get; }

		/// <summary>
		/// 邀请人（好友）的昵称
		/// </summary>
		public string Nick { get; }

		/// <summary>
		/// 邀请消息
		/// </summary>
		public string Message { get; }
	}
}
