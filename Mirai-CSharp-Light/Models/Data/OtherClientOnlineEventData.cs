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
	internal class OtherClientOnlineEventData : IOtherClientOnlineEventData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public ClientData client = new();

		[JsonIgnore]
		public IClientData Client => client;

		public long? kind;

		[JsonIgnore]
		public long? Kind => kind;

		public static OtherClientOnlineEventData Parse(JObject json) => JsonConvert.DeserializeObject<OtherClientOnlineEventData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
