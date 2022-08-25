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
	/// Bot主动退出一个群
	/// </summary>
	public interface IBotLeaveEventActiveHandler
	{
		/// <summary>
		/// 处理Bot主动退出一个群
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">Bot主动退出一个群事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleBotLeaveEventActive(IMiraiSession session, IBotLeaveEventActiveData e);
	}
}
