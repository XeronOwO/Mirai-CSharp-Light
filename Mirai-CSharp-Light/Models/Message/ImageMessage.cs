using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 图片消息
	/// </summary>
	public class ImageMessage : IChatMessage
	{
		/// <inheritdoc/>
		public string Type { get; } = "Image";


		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data
		{
			get => new()
			{
				["type"] = Type,
				["imageId"] = ImageId,
				["url"] = URL,
				["path"] = Path,
				["base64"] = Base64,
			};
		}

		/// <summary>
		/// 图片ID
		/// </summary>
		public string? ImageId { get; set; }

		/// <summary>
		/// 图片URL
		/// </summary>
		public string? URL { get; set; }

		/// <summary>
		/// 图片路径
		/// </summary>
		public string? Path { get; set; }

		/// <summary>
		/// 图片Base64
		/// </summary>
		public string? Base64 { get; set; }

		/// <summary>
		/// 构造图片消息
		/// </summary>
		/// <param name="imageId">图片ID</param>
		/// <param name="url">图片网址</param>
		/// <param name="path">图片路径（相对于MCL的路径，或者可以使用绝对路径）</param>
		/// <param name="base64">图片Base64</param>
		public ImageMessage(string? imageId, string? url, string? path, string? base64)
		{
			ImageId = imageId;
			URL = url;
			Path = path;
			Base64 = base64;
		}
	}
}
