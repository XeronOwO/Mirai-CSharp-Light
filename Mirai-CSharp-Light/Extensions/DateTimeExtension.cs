using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
	/// <summary>
	/// DateTime拓展
	/// </summary>
	public static class DateTimeExtension
	{
		/// <summary>
		/// DateTime转为QQ时间戳。精度：秒
		/// </summary>
		/// <param name="dt">DateTime类型</param>
		/// <returns>QQ时间戳</returns>
		public static int ToQQTimestamp(this DateTime dt)
		{
			var startDateTime = new DateTime(1970, 1, 1, 8, 0, 0);
			return Convert.ToInt32((dt - startDateTime).TotalSeconds);
		}
	}
}
