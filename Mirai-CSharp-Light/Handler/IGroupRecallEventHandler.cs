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
	/// 群消息撤回
	/// </summary>
	public interface IGroupRecallEventHandler
	{
		/// <summary>
		/// 处理群消息撤回
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">群消息撤回事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleGroupRecallEvent(IMiraiSession session, IGroupRecallEventData e);
	}
}
