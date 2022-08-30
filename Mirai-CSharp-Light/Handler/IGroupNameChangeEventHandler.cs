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
	/// 某个群名改变事件处理
	/// </summary>
	public interface IGroupNameChangeEventHandler
	{
		/// <summary>
		/// 处理某个群名改变
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">某个群名改变事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleGroupNameChangeEvent(IMiraiSession session, IGroupNameChangeEventData e);
	}
}
