using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// Bot被禁言事件信息
	/// </summary>
	public interface IBotMuteEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 禁言时长，单位为秒
		/// </summary>
		public int DurationSeconds { get; }

		/// <summary>
		/// 操作的管理员或群主信息
		/// </summary>
		public IGroupMemberData Operator { get; }
	}
}
