using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 修改群员设置的信息
	/// </summary>
	public class GroupMemberDataSet
	{
		/// <summary>
		/// 群名片（设为null则不修改）
		/// </summary>
		public string? name = null;

		/// <summary>
		/// 群头衔（设为null则不修改）
		/// </summary>
		public string? specialTitle = null;
	}
}
