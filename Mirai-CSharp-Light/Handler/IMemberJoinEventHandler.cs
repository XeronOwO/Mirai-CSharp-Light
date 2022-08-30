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
	/// 新人入群事件处理
	/// </summary>
	public interface IMemberJoinEventHandler
	{
		/// <summary>
		/// 处理新人入群
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">新人入群事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleMemberJoinEvent(IMiraiSession session, IMemberJoinEventData e);
	}
}
