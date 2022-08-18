using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 表情消息
	/// </summary>
	public class FaceMessage : IChatMessage
	{
		/// <inheritdoc/>
		public string Type { get; } = "Face";


		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data
		{
			get => new()
			{
				["type"] = Type,
				["faceId"] = FaceId,
				["name"] = Name,
			};
		}

		/// <summary>
		/// 表情ID
		/// </summary>
		public long? FaceId { get; set; }

		/// <summary>
		/// 表情名称
		/// </summary>
		public string? Name { get; set; }

		/// <summary>
		/// 表情消息
		/// </summary>
		/// <param name="faceId">表情ID</param>
		/// <param name="name">表情名字</param>
		public FaceMessage(long? faceId, string? name)
		{
			FaceId = faceId;
			Name = name;
		}
	}
}
