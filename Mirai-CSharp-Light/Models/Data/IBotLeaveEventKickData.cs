using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// Bot被踢出一个群
	/// </summary>
	public interface IBotLeaveEventKickData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// Bot被踢出的群的信息
		/// </summary>
		public IGroupData Group { get; }

		/// <summary>
		/// Bot被踢后获取操作人的 Member 对象
		/// </summary>
		public IGroupMemberData Operator { get; }
	}
}
