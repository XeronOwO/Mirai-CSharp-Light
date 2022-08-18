using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 群消息发送者信息
	/// </summary>
	public interface IGroupSenderData : ISenderData
	{
		/// <summary>
		/// 群昵称
		/// </summary>
		public string MemberName { get; }

		/// <summary>
		/// 群头衔
		/// </summary>
		public string SpecialTitle { get; }

		/// <summary>
		/// 群权限/身份
		/// </summary>
		public GroupPermission Permission { get; }

		/// <summary>
		/// 入群时间戳
		/// </summary>
		public long JoinTimestamp { get; }

		/// <summary>
		/// 入群时间日期
		/// </summary>
		public DateTime JoinDateTime { get; }

		/// <summary>
		/// 最后一次发言时间戳
		/// </summary>
		public long LastSpeakTimestamp { get; }

		/// <summary>
		/// 最后一次发言时间日期
		/// </summary>
		public DateTime LastSpeakDateTime { get; }

		/// <summary>
		/// 剩余禁言时间
		/// </summary>
		public int MuteTimeRemaining { get; }

		/// <summary>
		/// 群信息
		/// </summary>
		public IGroupData Group { get; }
	}
}
