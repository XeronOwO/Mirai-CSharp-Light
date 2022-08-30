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
	/// 匿名聊天事件处理
	/// </summary>
	public interface IGroupAllowAnonymousChatEventHandler
	{
		/// <summary>
		/// 处理匿名聊天
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">匿名聊天事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleGroupAllowAnonymousChatEvent(IMiraiSession session, IGroupAllowAnonymousChatEventData e);
	}
}
