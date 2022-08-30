using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 群成员信息
	/// </summary>
	public interface IGroupMemberData : IBasicGroupMemberData
	{
		/// <summary>
		/// 群头衔
		/// </summary>
		public string SpecialTitle { get; }

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
	}
}
