using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 群成员被取消禁言事件（该成员不是Bot）
	/// </summary>
	public interface IMemberUnmuteEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 被取消禁言的群员的信息
		/// </summary>
		public IGroupMemberData Member { get; }

		/// <summary>
		/// 操作者的信息，当null时为Bot操作
		/// </summary>
		public IGroupMemberData? Operator { get; }
	}
}
