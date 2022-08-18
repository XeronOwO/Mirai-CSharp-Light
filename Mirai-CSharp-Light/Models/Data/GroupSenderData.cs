using Mirai.CSharp.Light.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	internal class GroupSenderData : SenderData, IGroupSenderData
	{
		public string memberName = "";

		[JsonIgnore]
		public string MemberName { get => memberName; set => memberName = value; }

		public string specialTitle = "";

		[JsonIgnore]
		public string SpecialTitle { get => specialTitle; set => specialTitle = value; }

		public string permission = "";

		[JsonIgnore]
		public GroupPermission Permission { get => permission.ToGroupPermission(); set => permission = value.GetString(); }

		public long joinTimestamp;

		[JsonIgnore]
		public long JoinTimestamp { get => joinTimestamp; set => joinTimestamp = value; }

		[JsonIgnore]
		public DateTime JoinDateTime { get => joinTimestamp.ToDateTime(); set => joinTimestamp = value.ToTimestamp(); }

		public long lastSpeakTimestamp;

		[JsonIgnore]
		public long LastSpeakTimestamp { get => lastSpeakTimestamp; set => lastSpeakTimestamp = value; }

		[JsonIgnore]
		public DateTime LastSpeakDateTime { get => lastSpeakTimestamp.ToDateTime(); set => lastSpeakTimestamp = value.ToTimestamp(); }

		public int muteTimeRemaining;

		[JsonIgnore]
		public int MuteTimeRemaining { get => muteTimeRemaining; set => muteTimeRemaining = value; }

		public GroupData group = new();

		[JsonIgnore]
		public IGroupData Group => group;
	}
}
