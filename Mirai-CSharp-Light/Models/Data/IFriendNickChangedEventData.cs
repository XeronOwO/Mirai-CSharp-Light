using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 好友昵称改变事件信息
	/// </summary>
	public interface IFriendNickChangedEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 好友信息
		/// </summary>
		public IUserData Friend { get; }

		/// <summary>
		/// 原昵称
		/// </summary>
		public string From { get; }

		/// <summary>
		/// 新昵称
		/// </summary>
		public string To { get; }
	}
}
