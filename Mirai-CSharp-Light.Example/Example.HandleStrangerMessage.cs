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
	internal class ExampleStrangerMessageHandler : IStrangerMessageHandler
	{
		public bool HandleStrangerMessage(IMiraiSession session, IStrangerMessageData e)
		{
			// 处理陌生人消息

			// 返回false以继续执行队列后面的Handler
			// 返回true以阻止执行队列后面的Handler
			return false;
		}
	}
}
