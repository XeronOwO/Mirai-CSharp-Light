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
	/// 某群入群公告改变事件处理
	/// </summary>
	public interface IGroupEntranceAnnouncementChangeEventHandler
	{
		/// <summary>
		/// 处理某群入群公告改变
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">某群入群公告改变事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleGroupEntranceAnnouncementChangeEvent(IMiraiSession session, IGroupEntranceAnnouncementChangeEventData e);
	}
}
