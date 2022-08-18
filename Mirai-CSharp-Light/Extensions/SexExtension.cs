using Mirai.CSharp.Light.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
	internal static class SexExtension
	{
		public static string GetString(this Sex sex)
		{
			return sex switch
			{
				Sex.Unknown => "UNKNOWN",
				Sex.Male => "MALE",
				Sex.Female => "FEMALE",
				_ => throw new System.Exception("Sex转换成字符串失败"),
			};
		}
	}
}
