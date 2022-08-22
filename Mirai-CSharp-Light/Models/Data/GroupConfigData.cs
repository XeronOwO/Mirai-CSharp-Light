using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8603 // 可能返回 null 引用。
namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 群设置信息
	/// </summary>
	public class GroupConfigData
	{
		// *为了使用JsonConvert.DeserializeObject，违反了C#命名规则

		/// <summary>
		/// 群名
		/// </summary>
		public string name = "";

		/// <summary>
		/// 群公告
		/// </summary>
		public string announcement = "";

		/// <summary>
		/// 是否开启坦白说
		/// </summary>
		public bool confessTalk = true;

		/// <summary>
		/// 是否允许群员邀请
		/// </summary>
		public bool allowMemberInvite = true;

		/// <summary>
		/// 是否开启自动审批入群
		/// </summary>
		public bool autoApprove;

		/// <summary>
		/// 是否允许匿名聊天
		/// </summary>
		public bool anonymousChat = true;

		/// <summary>
		/// 从JObject解析为GroupConfigData
		/// </summary>
		/// <param name="json">JObject内容</param>
		/// <returns>解析的GroupConfigData</returns>
		public static GroupConfigData Parse(JObject json) => JsonConvert.DeserializeObject<GroupConfigData>(json.ToString());

		/// <summary>
		/// 将群设置转换成JObject
		/// </summary>
		/// <returns>转换成的JObject</returns>
		public JObject ToJObject() => JObject.Parse(JsonConvert.SerializeObject(this, Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
