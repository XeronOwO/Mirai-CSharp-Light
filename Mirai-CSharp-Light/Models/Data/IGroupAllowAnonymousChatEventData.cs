using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 匿名聊天事件信息
	/// </summary>
	public interface IGroupAllowAnonymousChatEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 原本匿名聊天是否开启
		/// </summary>
		public bool Origin { get; }

		/// <summary>
		/// 现在匿名聊天是否开启
		/// </summary>
		public bool Current { get; }

		/// <summary>
		/// 匿名聊天状态改变的群信息
		/// </summary>
		public IGroupData Group { get; }

		/// <summary>
		/// 操作的管理员或群主信息，当null时为Bot操作
		/// </summary>
		public IGroupMemberData? Operator { get; }
	}
}
