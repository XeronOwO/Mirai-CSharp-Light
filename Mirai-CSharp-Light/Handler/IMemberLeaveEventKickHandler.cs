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
	/// 成员被踢出群（该成员不是Bot）事件处理
	/// </summary>
	public interface IMemberLeaveEventKickHandler
	{
		/// <summary>
		/// 处理成员被踢出群
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">成员被踢出群事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleMemberLeaveEventKick(IMiraiSession session, IMemberLeaveEventKickData e);
	}
}
