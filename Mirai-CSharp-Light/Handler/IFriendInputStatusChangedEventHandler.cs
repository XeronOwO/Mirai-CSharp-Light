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
	/// 好友输入状态改变事件处理接口
	/// </summary>
	public interface IFriendInputStatusChangedEventHandler
	{
		/// <summary>
		/// 处理好友输入状态改变
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">好友输入状态改变事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleFriendInputStatusChangedEvent(IMiraiSession session, IFriendInputStatusChangedEventData e);
	}
}
