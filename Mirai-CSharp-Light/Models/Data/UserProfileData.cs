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
		public string Nickname { get => nickname; set => nickname = value; }

		public string email = "";

		[JsonIgnore]
		public string Email { get => email; set => email = value; }

		public int age;

		[JsonIgnore]
		public int Age { get => age; set => age = value; }

		public int level;

		[JsonIgnore]
		public int Level { get => level; set => level = value; }

		public string sign = "";

		[JsonIgnore]
		public string Sign { get => sign; set => sign = value; }

		public string sex = "";

		[JsonIgnore]
		public Sex Sex { get => sex.ToSex(); set => sign = value.GetString(); }

		public static UserProfileData Parse(JObject json)
		{
			return JsonConvert.DeserializeObject<UserProfileData>(json.ToString(Formatting.None));
		}
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
