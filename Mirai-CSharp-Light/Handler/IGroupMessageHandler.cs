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
	/// 群消息处理接口
	/// </summary>
	public interface IGroupMessageHandler
	{
		/// <summary>
		/// 处理群消息
		/// </summary>
		/// <param name="session">Mirai会话</param>
		/// <param name="e">群消息事件参数</param>
		/// <returns>返回true中断后续的消息处理</returns>
		public bool HandleGroupMessage(IMiraiSession session, IGroupMessageData e);
	}
}
