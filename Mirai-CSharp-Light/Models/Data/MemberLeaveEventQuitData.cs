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
	internal class MemberLeaveEventQuitData : IMemberLeaveEventQuitData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public BasicGroupMemberData member = new();

		[JsonIgnore]
		public IBasicGroupMemberData Member => member;

		public static MemberLeaveEventQuitData Parse(JObject json) => JsonConvert.DeserializeObject<MemberLeaveEventQuitData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
