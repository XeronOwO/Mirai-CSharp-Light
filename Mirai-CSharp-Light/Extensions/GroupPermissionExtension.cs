using Mirai.CSharp.Light.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
	internal static class GroupPermissionExtension
	{
		public static string GetString(this GroupPermission permission)
		{
			return permission switch
			{
				GroupPermission.Member => "MEMBER",
				GroupPermission.Administrator => "ADMINISTRATOR",
				GroupPermission.Owner => "OWNER",
				_ => throw new System.Exception("GroupPermission转换成字符串失败"),
			};
		}
	}
}
