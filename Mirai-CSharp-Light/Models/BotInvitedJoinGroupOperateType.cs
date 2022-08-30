using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models
{
	/// <summary>
	///Bot被邀请入群申请处理类型
	/// </summary>
	public enum BotInvitedJoinGroupOperateType
	{
		/// <summary>
		/// 同意邀请
		/// </summary>
		Accept,
		/// <summary>
		/// 拒绝邀请
		/// </summary>
		Deny,
	}
}
