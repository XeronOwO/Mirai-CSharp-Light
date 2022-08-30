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
	/// 群名片改动事件处理
	/// </summary>
	public interface IMemberCardChangeEventHandler
	{
		/// <summary>
		/// 处理群名片改动
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">群名片改动事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleMemberCardChangeEvent(IMiraiSession session, IMemberCardChangeEventData e);
	}
}
