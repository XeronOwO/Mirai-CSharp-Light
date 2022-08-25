using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// Bot在群里的权限被改变事件信息
	/// </summary>
	public interface IBotGroupPermissionChangeEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 原群权限/身份
		/// </summary>
		public GroupPermission Origin { get; }

		/// <summary>
		/// 现群权限/身份
		/// </summary>
		public GroupPermission Current { get; }

		/// <summary>
		/// 群信息
		/// </summary>
		public IGroupData Group { get; }
	}
}
