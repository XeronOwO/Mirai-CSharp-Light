using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 全体消息
	/// </summary>
	public class AtAllMessage : IChatMessage
	{
		/// <inheritdoc/>
		public string Type { get; } = "AtAll";

		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data
		{
			get => new()
			{
				["type"] = Type,
				["target"] = 0,
			};
		}

		/// <summary>
		/// At目标
		/// </summary>
		public long Target { get; set; }
	}
}
