using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 其他客户端上线事件信息
	/// </summary>
	public interface IOtherClientOnlineEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 其他客户端
		/// </summary>
		public IClientData Client { get; }

		/// <summary>
		/// 详细设备类型
		/// </summary>
		public long? Kind { get; }
	}
}
