using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 好友输入状态改变事件信息
	/// </summary>
	public interface IFriendInputStatusChangedEventData
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
		/// 是否正在输入
		/// </summary>
		public bool Inputting { get; }
	}
}
