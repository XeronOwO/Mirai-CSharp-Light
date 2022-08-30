using Mirai.CSharp.Light.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8603 // 可能返回 null 引用。
namespace Mirai.CSharp.Light.Models.Data
{
	internal class MemberLeaveEventKickData : IMemberLeaveEventKickData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public GroupMemberData member = new();

		[JsonIgnore]
		public IGroupMemberData Member => member;

		public GroupMemberData? @operator;

		[JsonIgnore]
		public IGroupMemberData? Operator => @operator;

		public static MemberLeaveEventKickData Parse(JObject json) => JsonConvert.DeserializeObject<MemberLeaveEventKickData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
