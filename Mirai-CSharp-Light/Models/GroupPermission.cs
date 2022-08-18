using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models
{
    /// <summary>
    /// 群聊权限/身份拓展功能类
    /// </summary>
    public static class GroupPermissionExtensions
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
			if (s.Equals("Owner", StringComparison.OrdinalIgnoreCase))
			{
				return GroupPermission.Owner;
			}
			if (s.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
			{
				return GroupPermission.Administrator;
			}
			throw new System.Exception("字符串解析成GroupPermission失败");
		}
	}

    /// <summary>
    /// 群聊权限/身份
    /// </summary>
    public enum GroupPermission
    {
        /// <summary>
        /// 成员
        /// </summary>
        Member,
        /// <summary>
        /// 管理员
        /// </summary>
        Administrator,
        /// <summary>
        /// 群主
        /// </summary>
        Owner,
    }
}
