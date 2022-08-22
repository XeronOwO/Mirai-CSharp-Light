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
    internal class UserData : IUserData
    {
        private long id;

        [JsonIgnore]
        public long Id => id;

        private string nickname = "";

		[JsonIgnore]
		public string Nickname => nickname;

		private string remark = "";

		[JsonIgnore]
		public string Remark => remark;

		public static UserData Parse(JObject json) => JsonConvert.DeserializeObject<UserData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
