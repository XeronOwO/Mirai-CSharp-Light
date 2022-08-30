using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 坦白说事件信息
	/// </summary>
	public interface IGroupAllowConfessTalkEventData
	{
		/// <summary>
		/// 原本坦白说是否开启
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 现在坦白说是否开启
		/// </summary>
		public bool Origin { get; }

		/// <summary>
		/// 现在是否处于全员禁言
		/// </summary>
		public bool Current { get; }

		/// <summary>
		/// 坦白说状态改变的群信息
		/// </summary>
		public IGroupData Group { get; }

		/// <summary>
		/// 是否Bot进行该操作
		/// </summary>
		public bool IsByBot { get; }
	}
}
