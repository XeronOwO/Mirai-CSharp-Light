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
	/// 群成员被取消禁言（该成员不是Bot）事件处理
	/// </summary>
	public interface IMemberUnmuteEventHandler
	{
		/// <summary>
		/// 处理群成员被取消禁言
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">群成员被取消禁言事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleMemberUnmuteEvent(IMiraiSession session, IMemberUnmuteEventData e);
	}
}
