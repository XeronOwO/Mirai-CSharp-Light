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
	internal class UserProfileData : IUserProfileData
	{
		public string nickname = "";

		[JsonIgnore]
		public string Nickname => nickname;

		public string email = "";

		[JsonIgnore]
		public string Email => email;

		public int age;

		[JsonIgnore]
		public int Age => age;

		public int level;

		[JsonIgnore]
		public int Level => level;

		public string sign = "";

		[JsonIgnore]
		public string Sign => sign;

		public string sex = "";

		[JsonIgnore]
		public Sex Sex { get => sex.ToSex(); }

		public static UserProfileData Parse(JObject json) => JsonConvert.DeserializeObject<UserProfileData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
