using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// At消息
	/// </summary>
	public class AtMessage : IChatMessage
	{
		/// <inheritdoc/>
		public string Type { get; } = "At";


		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data
		{
			get => new()
			{
				["type"] = Type,
				["target"] = Target,
			};
		}

		/// <summary>
		/// At目标
		/// </summary>
		public long Target { get; set; }

		/// <summary>
		/// 构造At消息
		/// </summary>
		/// <param name="target">At对象的QQ号</param>
		public AtMessage(long target)
		{
			Target = target;
		}
	}
}
