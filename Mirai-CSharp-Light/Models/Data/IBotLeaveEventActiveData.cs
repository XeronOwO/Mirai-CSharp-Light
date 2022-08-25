using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// Bot主动退出一个群信息
	/// </summary>
	public interface IBotLeaveEventActiveData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// Bot退出的群的信息
		/// </summary>
		public IGroupData Group { get; }
	}
}
