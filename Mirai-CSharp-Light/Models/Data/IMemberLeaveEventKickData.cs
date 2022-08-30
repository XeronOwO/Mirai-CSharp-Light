using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 成员被踢出群（该成员不是Bot）事件信息
	/// </summary>
	public interface IMemberLeaveEventKickData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 被踢者的信息
		/// </summary>
		public IGroupMemberData Member { get; }

		/// <summary>
		/// 操作的管理员或群主信息，当null时为Bot操作
		/// </summary>
		public IGroupMemberData? Operator { get; }
	}
}
