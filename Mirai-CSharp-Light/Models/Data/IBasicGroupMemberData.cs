using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 基本群成员信息
	/// </summary>
	public interface IBasicGroupMemberData : IIdData
	{
		/// <summary>
		/// 群昵称
		/// </summary>
		public string MemberName { get; }

		/// <summary>
		/// 群权限/身份
		/// </summary>
		public GroupPermission Permission { get; }

		/// <summary>
		/// 群信息
		/// </summary>
		public IGroupData Group { get; }
	}
}
