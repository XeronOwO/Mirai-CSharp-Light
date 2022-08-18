using Mirai.CSharp.Light.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.EventArgs
{
	/// <summary>
	/// 群消息事件参数接口
	/// </summary>
	public interface IGroupMessageEventArgs : IMessageEventArgs
	{
		/// <summary>
		/// 发送者信息
		/// </summary>
		public IGroupMessageSenderData Sender { get; }
	}
}
