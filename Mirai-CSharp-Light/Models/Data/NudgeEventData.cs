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
	internal class NudgeEventData : INudgeEventData
	{
		public string type = "";

		[JsonIgnore]
		public string Type => type;

		public long fromId;

		[JsonIgnore]
		public long FromId => fromId;

		public NudgeSubjectData subject = new();

		[JsonIgnore]
		public INudgeSubjectData Subject => subject;

		public string action = "";

		[JsonIgnore]
		public string Action => action;

		public string suffix = "";

		[JsonIgnore]
		public string Suffix => suffix;

		public long target;

		[JsonIgnore]
		public long Target => target;

		public static NudgeEventData Parse(JObject json) => JsonConvert.DeserializeObject<NudgeEventData>(json.ToString(Formatting.None));
	}
}
#pragma warning restore CS8603 // 可能返回 null 引用。
