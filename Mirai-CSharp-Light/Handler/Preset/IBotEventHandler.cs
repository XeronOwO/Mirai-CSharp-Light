using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Handler.Preset
{
	/// <summary>
	/// Bot自身事件处理接口
	/// </summary>
	public interface IBotEventHandler : IBotOnlineEventHandler, IBotOfflineEventActiveHandler, IBotOfflineEventForceHandler, IBotOfflineEventDroppedHandler, IBotReloginEventHandler
	{

	}
}
