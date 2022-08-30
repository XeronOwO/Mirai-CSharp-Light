using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Handler
{
	/// <summary>
	/// 允许群员邀请好友加群事件处理
	/// </summary>
	public interface IGroupAllowMemberInviteEventHandler
	{
		/// <summary>
		/// 处理允许群员邀请好友加群
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">允许群员邀请好友加群事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleGroupAllowMemberInviteEvent(IMiraiSession session, IGroupAllowMemberInviteEventData e);
	}
}
