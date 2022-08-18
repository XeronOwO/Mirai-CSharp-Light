using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
	internal static class StringToLiteralExtension
	{
		public static string ReplaceReturn(this string str)
		{
			return str.Replace("\r", @"\r")
					  .Replace("\n", @"\n")
					  ;
		}
	}
}
