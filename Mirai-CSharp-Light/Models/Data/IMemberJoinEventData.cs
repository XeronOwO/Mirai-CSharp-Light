using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 某个群名改变事件信息
	/// </summary>
	public interface IMemberJoinEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 新人信息
		/// </summary>
		public IGroupMemberData Member { get; }

		/// <summary>
		/// 如果被要求入群的话，则为邀请人的 Member 对象
		/// </summary>
		public IGroupMemberData? Invitor { get; }
	}
}
