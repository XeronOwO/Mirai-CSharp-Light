using Mirai.CSharp.Light.Handler;
using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Models.Message;
using Mirai.CSharp.Light.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Example
{
	internal class ExampleTempMessageHandler : ITempMessageHandler // 可以添加多个Handler
	{
		public bool HandleTempMessage(IMiraiSession session, ITempMessageData e)
		{
			// 处理群消息

			/*
			// 发送群消息
			session.SendGroupMessage(e.Sender.Group.Id, new IChatMessage[]
			{
				new PlainMessage("收到来自"),
				new AtMessage(e.Sender.Id),
				new PlainMessage("的消息。"),
			});
			*/

			// 返回false以继续执行队列后面的Handler
			// 返回true以阻止执行队列后面的Handler
			return false;
		}
	}
}
