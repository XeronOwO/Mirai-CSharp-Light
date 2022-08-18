using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 消息源
	/// </summary>
	public class SourceMessage : IChatMessage
	{
		/// <inheritdoc/>
		public string Type { get; } = "Source";


		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data
		{
			get => new()
			{
				["type"] = Type,
				["id"] = Id,
				["time"] = Time,
			};
		}

		/// <summary>
		/// 消息ID
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 时间戳
		/// </summary>
		public long? Time { get; set; }
	}
}
