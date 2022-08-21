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
	/// 临时消息处理接口
	/// </summary>
	public interface ITempMessageHandler
	{
		/// <summary>
		/// 处理临时消息
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">临时消息事件信息</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleTempMessage(IMiraiSession session, ITempMessageData e);
	}
}
