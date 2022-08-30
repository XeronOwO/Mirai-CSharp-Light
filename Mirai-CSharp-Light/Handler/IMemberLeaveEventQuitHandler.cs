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
	/// 成员主动离群（该成员不是Bot）
	/// </summary>
	public interface IMemberLeaveEventQuitHandler
	{
		/// <summary>
		/// 处理成员主动离群
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">成员主动离群事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleMemberLeaveEventQuit(IMiraiSession session, IMemberLeaveEventQuitData e);
	}
}
