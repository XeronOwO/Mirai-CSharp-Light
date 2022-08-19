using Mirai.CSharp.Light.Exception;
using Mirai.CSharp.Light.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
    /// <summary>
    /// 上下文类型的拓展功能类
    /// </summary>
    public static class ContextTypeExtension
	{
		/// <summary>
		/// 上下文类型转成字符串
		/// </summary>
		/// <param name="type">上下文类型</param>
		/// <returns>转换的字符串</returns>
		/// <exception cref="System.Exception"></exception>
		public static string GetString(this ContextType type)
		{
			return type switch
			{
				ContextType.Friend => "Friend",
				ContextType.Group => "Group",
				ContextType.Temp => "Temp",
				_ => throw new MiraiException("ContextTypeExtension", "未知的上下文类型"),
			};
		}
	}
}
