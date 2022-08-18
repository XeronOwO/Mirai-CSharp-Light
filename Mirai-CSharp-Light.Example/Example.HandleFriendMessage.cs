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
	internal class ExampleFriendMessageHandler : IFriendMessageHandler
	{
		public bool HandleFriendMessage(IMiraiSession session, IFriendMessageData e)
		{
			// 处理好友消息

			/*
			// 发送好友消息
			session.SendFriendMessage(e.Sender.Id, new IChatMessage[]
			{
				new PlainMessage("收到消息。"),
			});
			*/

			// 返回false以继续执行队列后面的Handler
			// 返回true以阻止执行队列后面的Handler
			return false;
		}
	}
}
