using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// Bot因群主解散群而退出群, 操作人一定是群主
	/// </summary>
	public interface IBotLeaveEventDisbandData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// Bot所在被解散的群的信息
		/// </summary>
		public IGroupData Group { get; }

		/// <summary>
		/// Bot离开群后获取操作人的 Member 对象
		/// </summary>
		public IGroupMemberData Operator { get; }
	}
}
