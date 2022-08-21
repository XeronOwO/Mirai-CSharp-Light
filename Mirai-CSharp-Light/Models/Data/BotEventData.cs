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
	internal class BotEventData : IBotEventData
	{
		public string type = "";

		[JsonIgnore]
		public string Type { get => type; set => type = value; }

		public long qq;

		[JsonIgnore]
		public long QQ { get => qq; set => qq = value; }

		public static BotEventData Parse(JObject json)
		{
			return JsonConvert.DeserializeObject<BotEventData>(json.ToString(Formatting.None));
		}
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
