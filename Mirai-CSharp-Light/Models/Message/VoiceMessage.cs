using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 语音消息
	/// </summary>
	public class VoiceMessage : IChatMessage
	{
		/// <inheritdoc/>
		public string Type { get; } = "Voice";


		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data
		{
			get => new()
			{
				["type"] = Type,
				["voiceId"] = VoiceId,
				["url"] = URL,
				["path"] = Path,
				["base64"] = Base64,
				["length"] = Length,
			};
		}

		/// <summary>
		/// 语音ID
		/// </summary>
		public string? VoiceId { get; set; }

		/// <summary>
		/// 语音URL
		/// </summary>
		public string? URL { get; set; }

		/// <summary>
		/// 语音路径
		/// </summary>
		public string? Path { get; set; }

		/// <summary>
		/// 语音Base64
		/// </summary>
		public string? Base64 { get; set; }

		/// <summary>
		/// 语音长度
		/// </summary>
		public string? Length { get; set; }

		/// <summary>
		/// 构造语音消息
		/// </summary>
		/// <param name="imageId">语音ID</param>
		/// <param name="url">语音网址</param>
		/// <param name="path">语音路径（相对于MCL的路径，或者可以使用绝对路径）</param>
		/// <param name="base64">语音Base64</param>
		/// <param name="length">语音长度</param>
		public VoiceMessage(string? imageId, string? url, string? path, string? base64, string? length)
		{
			VoiceId = imageId;
			URL = url;
			Path = path;
			Base64 = base64;
			Length = length;
		}
	}
}
