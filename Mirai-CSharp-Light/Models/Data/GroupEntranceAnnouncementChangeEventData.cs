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
	internal class GroupEntranceAnnouncementChangeEventData : IGroupEntranceAnnouncementChangeEventData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public string origin = "";

		[JsonIgnore]
		public string Origin => origin;

		public string current = "";

		[JsonIgnore]
		public string Current => current;

		public GroupData group = new();

		[JsonIgnore]
		public IGroupData Group => group;

		public GroupMemberData? @operator;

		[JsonIgnore]
		public IGroupMemberData? Operator => @operator;

		public static GroupEntranceAnnouncementChangeEventData Parse(JObject json) => JsonConvert.DeserializeObject<GroupEntranceAnnouncementChangeEventData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
