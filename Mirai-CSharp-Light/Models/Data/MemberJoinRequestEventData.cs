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
	internal class MemberJoinRequestEventData : IMemberJoinRequestEventData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public long eventId;

		[JsonIgnore]
		public long EventId => eventId;

		public long fromId;

		[JsonIgnore]
		public long FromId => fromId;

		public long groupId;

		[JsonIgnore]
		public long GroupId => groupId;

		public string groupName = "";

		[JsonIgnore]
		public string GroupName => groupName;

		public string nick = "";

		[JsonIgnore]
		public string Nick => nick;

		public string message = "";

		[JsonIgnore]
		public string Message => message;

		public static MemberJoinRequestEventData Parse(JObject json) => JsonConvert.DeserializeObject<MemberJoinRequestEventData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
