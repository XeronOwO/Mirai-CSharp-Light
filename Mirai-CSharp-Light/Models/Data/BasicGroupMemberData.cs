using Mirai.CSharp.Light.Extensions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8603 // 可能返回 null 引用。
namespace Mirai.CSharp.Light.Models.Data
{
	internal class BasicGroupMemberData : IBasicGroupMemberData
	{
		public long id;

		[JsonIgnore]
		public long Id => id;

		public string memberName = "";

		[JsonIgnore]
		public string MemberName => memberName;

		public string permission = "";

		[JsonIgnore]
		public GroupPermission Permission { get => permission.ToGroupPermission(); }

		public GroupData group = new();

		[JsonIgnore]
		public IGroupData Group => group;

		public static BasicGroupMemberData Parse(JObject json) => JsonConvert.DeserializeObject<BasicGroupMemberData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
