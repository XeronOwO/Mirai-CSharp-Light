using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// Xml消息
	/// </summary>
	public class XmlMessage : IChatMessage
	{
		/// <inheritdoc/>
		public string Type { get; } = "Xml";


		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data
		{
			get => new()
			{
				["type"] = Type,
				["xml"] = XML,
			};
		}

		/// <summary>
		/// 文本
		/// </summary>
		public string XML { get; set; } = "";

		/// <summary>
		/// 构造XML消息
		/// </summary>
		/// <param name="xml">XML内容</param>
		public XmlMessage(string xml)
		{
			XML = xml;
		}
	}
}
