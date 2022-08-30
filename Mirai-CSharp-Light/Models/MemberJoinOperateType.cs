using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models
{
	/// <summary>
	/// 用户入群申请处理类型
	/// </summary>
	public enum MemberJoinOperateType
	{
		/// <summary>
		/// 同意入群
		/// </summary>
		Accept,
		/// <summary>
		/// 拒绝入群
		/// </summary>
		Deny,
		/// <summary>
		/// 忽略请求
		/// </summary>
		Ignore,
		/// <summary>
		/// 拒绝入群并添加黑名单，不再接收该用户的入群申请
		/// </summary>
		DenyBlacklist,
		/// <summary>
		/// 忽略入群并添加黑名单，不再接收该用户的入群申请
		/// </summary>
		IgnoreBlacklist,
	}
}
