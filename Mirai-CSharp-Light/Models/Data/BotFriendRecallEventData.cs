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
	internal class FriendRecallEventData : IFriendRecallEventData
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
		public int Time => Time;

		public long @operator;

		[JsonIgnore]
		public long Operator => @operator;

		public static FriendRecallEventData Parse(JObject json) => JsonConvert.DeserializeObject<FriendRecallEventData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
