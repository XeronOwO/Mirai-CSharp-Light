using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models
{
	/// <summary>
	/// 好友申请处理类型
	/// </summary>
	public enum NewFriendOperateType
	{
		/// <summary>
		/// 同意添加好友
		/// </summary>
		Accept,
		/// <summary>
		/// 拒绝添加好友
		/// </summary>
		Deny,
		/// <summary>
		/// 拒绝添加好友并添加黑名单，不再接收该用户的好友申请
		/// </summary>
		DenyBlacklist,
	}
}
