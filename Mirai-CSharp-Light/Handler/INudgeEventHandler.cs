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
	/// 戳一戳事件处理
	/// </summary>
	public interface INudgeEventHandler
	{
		/// <summary>
		/// 处理戳一戳事件
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">戳一戳事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleNudgeEvent(IMiraiSession session, INudgeEventData e);
	}
}
