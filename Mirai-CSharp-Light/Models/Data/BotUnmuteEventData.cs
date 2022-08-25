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
	internal class BotUnmuteEventData : IBotUnmuteEventData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public GroupMemberData @operator = new();

		[JsonIgnore]
		public IGroupMemberData Operator => @operator;

		public static BotUnmuteEventData Parse(JObject json) => JsonConvert.DeserializeObject<BotUnmuteEventData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
