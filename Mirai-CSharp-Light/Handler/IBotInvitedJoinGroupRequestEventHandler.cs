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
	/// Bot被邀请入群申请事件处理
	/// </summary>
	public interface IBotInvitedJoinGroupRequestEventHandler
	{
		/// <summary>
		/// 处理Bot被邀请入群申请
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">Bot被邀请入群申请事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleBotInvitedJoinGroupRequestEvent(IMiraiSession session, IBotInvitedJoinGroupRequestEventData e);
	}
}
