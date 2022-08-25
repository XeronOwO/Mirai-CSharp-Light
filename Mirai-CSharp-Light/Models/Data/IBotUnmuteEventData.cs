using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// Bot被取消禁言事件信息
	/// </summary>
	public interface IBotUnmuteEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 操作的管理员或群主信息
		/// </summary>
		public IGroupMemberData Operator { get; }
	}
}
