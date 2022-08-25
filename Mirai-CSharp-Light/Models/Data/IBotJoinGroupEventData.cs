using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// Bot加入了一个新群事件信息
	/// </summary>
	public interface IBotJoinGroupEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// Bot新加入群的信息
		/// </summary>
		public IGroupData Group { get; }

		/// <summary>
		/// 如果被要求入群的话，则为邀请人的 Member 对象
		/// </summary>
		public IGroupMemberData? Invitor { get; }
	}
}
