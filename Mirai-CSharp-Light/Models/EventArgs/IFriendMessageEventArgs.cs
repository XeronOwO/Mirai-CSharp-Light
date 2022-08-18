using Mirai.CSharp.Light.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.EventArgs
{
	/// <summary>
	/// 好友消息事件参数
	/// </summary>
	public interface IFriendMessageEventArgs
	{
		/// <summary>
		/// 发送者信息
		/// </summary>
		public IFriendMessageSenderData Sender { get; }
	}
}
