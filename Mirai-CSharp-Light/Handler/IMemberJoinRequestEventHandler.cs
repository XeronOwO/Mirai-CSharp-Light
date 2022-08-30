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
	/// 用户入群申请（Bot需要有管理员权限）事件处理
	/// </summary>
	public interface IMemberJoinRequestEventHandler
	{
		/// <summary>
		/// 处理用户入群申请
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">用户入群申请事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleMemberJoinRequestEvent(IMiraiSession session, IMemberJoinRequestEventData e);
	}
}
