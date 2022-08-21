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
	/// Bot登录成功处理接口
	/// </summary>
	public interface IBotOnlineEventHandler
	{
		/// <summary>
		/// 处理Bot登录成功
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">Bot登录成功事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleBotOnlineEvent(IMiraiSession session, IBotEventData e);
	}
}
