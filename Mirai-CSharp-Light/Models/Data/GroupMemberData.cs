using Mirai.CSharp.Light.Extensions;
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
	internal class GroupMemberData : IGroupMemberData
	{
		public long id;

		[JsonIgnore]
		public long Id => id;

		public string memberName = "";

		[JsonIgnore]
		public string MemberName => memberName;

		public string specialTitle = "";

		[JsonIgnore]
		public string SpecialTitle => specialTitle;

		public string permission = "";

		[JsonIgnore]
		public GroupPermission Permission { get => permission.ToGroupPermission(); }

		public long joinTimestamp;

		[JsonIgnore]
		public long JoinTimestamp => joinTimestamp;

		[JsonIgnore]
		public DateTime JoinDateTime { get => joinTimestamp.ToDateTime(); }

		public long lastSpeakTimestamp;

		[JsonIgnore]
		public long LastSpeakTimestamp { get => lastSpeakTimestamp; }

		[JsonIgnore]
		public DateTime LastSpeakDateTime { get => lastSpeakTimestamp.ToDateTime(); }

		public int muteTimeRemaining;

		[JsonIgnore]
		public int MuteTimeRemaining => muteTimeRemaining;

		public GroupData group = new();

		[JsonIgnore]
		public IGroupData Group => group;

		public static GroupMemberData Parse(JObject json) => JsonConvert.DeserializeObject<GroupMemberData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
