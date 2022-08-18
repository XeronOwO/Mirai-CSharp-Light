using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
    /// <summary>
    /// 好友消息发送者信息
    /// </summary>
    public interface IFriendMessageSenderData : IMessageSenderData
	{
		/// <summary>
		/// 昵称
		/// </summary>
		public string Nickname { get; }

		/// <summary>
		/// 评论
		/// </summary>
		public string Remark { get; }
	}
}
