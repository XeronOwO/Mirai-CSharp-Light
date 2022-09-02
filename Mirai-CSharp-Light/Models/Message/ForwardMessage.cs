using Mirai.CSharp.Light.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 转发消息
	/// </summary>
	public class ForwardMessage : IChatMessage
	{
		/// <summary>
		/// ForwardMessage构造函数
		/// </summary>
		public ForwardMessage()
		{
			NodeList = Array.Empty<NodeMessage>();
		}

		/// <summary>
		/// ForwardMessage构造函数
		/// </summary>
		/// <param name="nodeList">消息节点数组</param>
		public ForwardMessage(NodeMessage[] nodeList)
		{
			NodeList = nodeList;
		}

		/// <inheritdoc/>
		public string Type { get; } = "Forward";

		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data
		{
			get => new()
			{
				["type"] = Type,
				["nodeList"] = NodeList.ToJArray(),
			};
		}

		/// <summary>
		/// 消息节点
		/// </summary>
		public NodeMessage[] NodeList { get; set; }
	}
}
