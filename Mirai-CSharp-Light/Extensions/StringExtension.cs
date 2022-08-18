using Mirai.CSharp.Light.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
	internal static class StringExtension
	{
		public static GroupPermission ToGroupPermission(this string s)
		{
			if (s.Equals("Member", StringComparison.OrdinalIgnoreCase))
			{
				return GroupPermission.Member;
			}
			if (s.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
			{
				return GroupPermission.Administrator;
			}
			if (s.Equals("Owner", StringComparison.OrdinalIgnoreCase))
			{
				return GroupPermission.Owner;
			}
			throw new System.Exception("字符串解析成GroupPermission失败");
		}

		public static Sex ToSex(this string s)
		{
			if (s.Equals("Unknown", StringComparison.OrdinalIgnoreCase))
			{
				return Sex.Unknown;
			}
			if (s.Equals("Male", StringComparison.OrdinalIgnoreCase))
			{
				return Sex.Male;
			}
			if (s.Equals("Female", StringComparison.OrdinalIgnoreCase))
			{
				return Sex.Female;
			}
			throw new System.Exception("字符串解析成Sex失败");
		}

		public static string ReplaceReturn(this string str)
		{
			return str.Replace("\r", @"\r")
					  .Replace("\n", @"\n")
					  ;
		}
	}
}
