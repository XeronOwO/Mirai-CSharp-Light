using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 客户端信息
	/// </summary>
	public interface IClientData
	{
		/// <summary>
		/// 客户端标识号
		/// </summary>
		public long Id { get; }

		/// <summary>
		/// 客户端类型
		/// </summary>
		public string Platform { get; }
	}
}
