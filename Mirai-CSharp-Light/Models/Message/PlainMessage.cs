using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 文本消息
	/// </summary>
	public class PlainMessage : IChatMessage
	{
		/// <inheritdoc/>
		public string Type { get; } = "Plain";


		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data
		{
			get => new()
			{
				["type"] = Type,
				["text"] = Text,
			};
		}

		/// <summary>
		/// 文本
		/// </summary>
		public string Text { get; set; } = "";

		/// <summary>
		/// 构造文本消息
		/// </summary>
		/// <param name="text">文本内容</param>
		public PlainMessage(string text)
		{
			Text = text;
		}
	}
}
