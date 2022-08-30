using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 成员主动离群（该成员不是Bot）
	/// </summary>
	public interface IMemberLeaveEventQuitData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 退群群员的信息
		/// </summary>
		public IBasicGroupMemberData Member { get; }
	}
}
