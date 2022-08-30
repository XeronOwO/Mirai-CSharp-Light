using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 允许群员邀请好友加群
	/// </summary>
	public interface IGroupAllowMemberInviteEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 原本是否允许群员邀请好友加群
		/// </summary>
		public bool Origin { get; }

		/// <summary>
		/// 现在是否允许群员邀请好友加群
		/// </summary>
		public bool Current { get; }

		/// <summary>
		/// 允许群员邀请好友加群状态改变的群信息
		/// </summary>
		public IGroupData Group { get; }

		/// <summary>
		/// 操作的管理员或群主信息，当null时为Bot操作
		/// </summary>
		public IGroupMemberData? Operator { get; }
	}
}
