using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirai.CSharp.Light.Extensions;
using Newtonsoft.Json;

namespace Mirai.CSharp.Light.Models.Data
{
	internal class NudgeSubjectData : INudgeSubjectData
	{
		public string kind = "";

		[JsonIgnore]
		public ContextType Kind => kind.ToContextType();

		public long id;

		[JsonIgnore]
		public long Id => id;
	}
}
