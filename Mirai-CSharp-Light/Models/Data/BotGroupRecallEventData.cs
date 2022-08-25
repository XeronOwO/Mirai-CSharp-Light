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
	internal class GroupRecallEventData : IGroupRecallEventData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public long authorId;

		[JsonIgnore]
		public long AuthorId => authorId;

		public int messageId;

		[JsonIgnore]
		public int MessageId => messageId;

		public int time;

		[JsonIgnore]
		public int Time => time;

		public GroupData group = new();

		[JsonIgnore]
		public IGroupData Group => group;

		public GroupMemberData @operator = new();

		[JsonIgnore]
		public IGroupMemberData Operator => @operator;

		public static GroupRecallEventData Parse(JObject json) => JsonConvert.DeserializeObject<GroupRecallEventData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
