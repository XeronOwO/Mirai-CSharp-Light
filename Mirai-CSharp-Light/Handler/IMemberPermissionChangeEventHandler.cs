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
	/// 成员权限改变（该成员不是Bot）事件处理
	/// </summary>
	public interface IMemberPermissionChangeEventHandler
	{
		/// <summary>
		/// 处理成员权限改变
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">成员权限改变事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleMemberPermissionChangeEvent(IMiraiSession session, IMemberPermissionChangeEventData e);
	}
}
