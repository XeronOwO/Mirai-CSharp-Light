using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Handler.Preset
{
	/// <summary>
	/// 预设消息事件处理接口
	/// </summary>
	public interface IMessageEventHandler : IFriendMessageHandler, IGroupMessageHandler, ITempMessageHandler, IStrangerMessageHandler
	{

	}
}
