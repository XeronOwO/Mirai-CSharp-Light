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
	/// 添加好友申请事件处理
	/// </summary>
	public interface INewFriendRequestEventHandler
	{
		/// <summary>
		/// 处理添加好友申请
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">添加好友申请事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleNewFriendRequestEvent(IMiraiSession session, INewFriendRequestEventData e);
	}
}
