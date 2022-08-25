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
	internal class BotLeaveEventActiveData : IBotLeaveEventActiveData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public GroupData group = new();

		[JsonIgnore]
		public IGroupData Group => group;

		public static BotLeaveEventActiveData Parse(JObject json) => JsonConvert.DeserializeObject<BotLeaveEventActiveData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
