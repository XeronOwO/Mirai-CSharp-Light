using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 用户入群申请（Bot需要有管理员权限）事件信息
	/// </summary>
	public interface IMemberJoinRequestEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 事件标识，响应该事件时的标识
		/// </summary>
		public long EventId { get; }

		/// <summary>
		/// 申请人QQ号
		/// </summary>
		public long FromId { get; }

		/// <summary>
		/// 申请人申请入群的群号
		/// </summary>
		public long GroupId { get; }

		/// <summary>
		/// 申请人申请入群的群名称
		/// </summary>
		public string GroupName { get; }

		/// <summary>
		/// 申请人的昵称或群名片
		/// </summary>
		public string Nick { get; }

		/// <summary>
		/// 申请消息
		/// </summary>
		public string Message { get; }
	}
}
