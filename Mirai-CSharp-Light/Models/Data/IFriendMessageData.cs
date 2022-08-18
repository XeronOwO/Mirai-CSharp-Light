using Mirai.CSharp.Light.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 群消息信息
	/// </summary>
	public interface IFriendMessageData
	{
		/// <summary>
		/// 消息类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 消息发送者信息
		/// </summary>
		public IUserData Sender { get; }

		/// <summary>
		/// 消息链
		/// </summary>
		public IChatMessage[] MessageChain { get; }
	}
}
