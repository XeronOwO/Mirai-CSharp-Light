using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 某个群名改变事件信息
	/// </summary>
	public interface IGroupNameChangeEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 原群名
		/// </summary>
		public string Origin { get; }

		/// <summary>
		/// 新群名
		/// </summary>
		public string Current { get; }

		/// <summary>
		/// 群名改名的群信息
		/// </summary>
		public IGroupData Group { get; }

		/// <summary>
		/// 操作的管理员或群主信息，当null时为Bot操作
		/// </summary>
		public IGroupMemberData? Operator { get; }
	}
}
