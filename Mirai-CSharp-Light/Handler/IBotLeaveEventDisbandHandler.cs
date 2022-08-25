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
	/// Bot因群主解散群而退出群处理接口
	/// </summary>
	public interface IBotLeaveEventDisbandHandler
	{
		/// <summary>
		/// 处理Bot因群主解散群而退出群
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">Bot因群主解散群而退出群事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleBotLeaveEventDisband(IMiraiSession session, IBotLeaveEventDisbandData e);
	}
}
