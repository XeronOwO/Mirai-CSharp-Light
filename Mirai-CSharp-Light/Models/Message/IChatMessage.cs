using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 聊天消息接口
	/// </summary>
	public interface IChatMessage
	{
		/// <summary>
		/// 消息类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data { get; }
	}
}
