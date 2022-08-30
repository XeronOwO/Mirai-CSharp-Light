using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 群名片改动
	/// </summary>
	public interface IMemberCardChangeEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 原本名片
		/// </summary>
		public string Origin { get; }

		/// <summary>
		/// 现在名片
		/// </summary>
		public string Current { get; }

		/// <summary>
		/// 名片改动的群员的信息
		/// </summary>
		public IBasicGroupMemberData Member { get; }
	}
}
