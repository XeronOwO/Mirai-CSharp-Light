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
	/// 其他客户端上线事件处理
	/// </summary>
	public interface IOtherClientOnlineEventHandler
	{
		/// <summary>
		/// 处理其他客户端上线
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">其他客户端上线事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleOtherClientOnlineEvent(IMiraiSession session, IOtherClientOnlineEventData e);
	}
}
