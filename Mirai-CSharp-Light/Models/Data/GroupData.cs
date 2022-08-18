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
    internal class GroupData : IGroupData
    {
		public long id;

        [JsonIgnore]
        public long Id { get => id; set => id = value; }

		public string name = "";

		[JsonIgnore]
		public string Name { get => name; set => name = value; }

		public string permission = "";

		[JsonIgnore]
		public GroupPermission Permission { get => permission.ToGroupPermission(); set => permission = value.GetString(); }

        public static GroupData Parse(JObject json) => JsonConvert.DeserializeObject<GroupData>(json.ToString(Formatting.None));
    }
}
#pragma warning restore CS8603 // 可能返回 null 引用。
