using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// 聊天消息接口数组拓展功能类
	/// </summary>
	public static class IChatMessageArrayExternsion
	{
		/// <summary>
		/// 消息聊天接口数组转换成JArray
		/// </summary>
		/// <param name="chain">消息链</param>
		/// <returns>转换成的JArray</returns>
		public static JArray ToJArray(this IChatMessage[] chain)
		{
			var array = new JArray();
			foreach (var item in chain)
			{
				array.Add(item.Data);
			}
			return array;
		}
	}

	/// <summary>
	/// 聊天消息接口
	/// </summary>
	public interface IChatMessage
	{
		/// <summary>
		/// 消息类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data { get; }
	}
}
