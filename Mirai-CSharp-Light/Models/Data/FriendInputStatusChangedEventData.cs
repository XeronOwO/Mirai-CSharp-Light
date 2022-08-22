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
	internal class FriendInputStatusChangedEventData : IFriendInputStatusChangedEventData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public UserData friend = new();

		[JsonIgnore]
		public IUserData Friend => friend;

		public bool inputting;

		[JsonIgnore]
		public bool Inputting => inputting;

		public static FriendInputStatusChangedEventData Parse(JObject json) => JsonConvert.DeserializeObject<FriendInputStatusChangedEventData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
