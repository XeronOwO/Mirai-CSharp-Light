using Mirai.CSharp.Light.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
	/// <summary>
	/// 群聊权限/身份拓展功能类
	/// </summary>
	public static class GroupPermissionExtension
	{
		/// <summary>
		/// 从string解析为GroupPermission，不区分大小写
		/// </summary>
		/// <param name="s">需要解析的字符串</param>
		/// <returns>解析出的GroupPermission</returns>
		/// <exception cref="System.Exception"></exception>
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

		/// <summary>
		/// 从GroupPermission转换成string
		/// </summary>
		/// <param name="permission">需要转换的群权限</param>
		/// <returns>转换成的string</returns>
		/// <exception cref="System.Exception"></exception>
		public static string GetString(this GroupPermission permission)
		{
			return permission switch
			{
				GroupPermission.Member => "Member",
				GroupPermission.Administrator => "Administrator",
				GroupPermission.Owner => "Owner",
				_ => throw new System.Exception("GroupPermission转换成字符串失败"),
			};
		}
	}
}
