using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 闪照消息
	/// </summary>
	public class FlashImageMessage : ImageMessage
	{
		/// <inheritdoc/>
		public new string Type { get; } = "FlashImage";

		/// <summary>
		/// 构造闪照消息
		/// </summary>
		/// <param name="imageId">闪照ID</param>
		/// <param name="url">闪照网址</param>
		/// <param name="path">闪照路径（相对于MCL的路径，或者可以使用绝对路径）</param>
		/// <param name="base64">闪照Base64</param>
		public FlashImageMessage(string? imageId, string? url, string? path, string? base64) : base(imageId, url, path, base64)
		{
		}
	}
}
