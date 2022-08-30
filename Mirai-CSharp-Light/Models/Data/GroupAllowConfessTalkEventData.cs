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
	internal class GroupAllowConfessTalkEventData : IGroupAllowConfessTalkEventData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public bool origin;

		[JsonIgnore]
		public bool Origin => origin;

		public bool current;

		[JsonIgnore]
		public bool Current => current;

		public GroupData group = new();

		[JsonIgnore]
		public IGroupData Group => group;

		public bool isByBot;

		[JsonIgnore]
		public bool IsByBot => isByBot;

		public static GroupAllowConfessTalkEventData Parse(JObject json) => JsonConvert.DeserializeObject<GroupAllowConfessTalkEventData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
