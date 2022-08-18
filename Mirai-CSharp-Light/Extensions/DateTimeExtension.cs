using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
	internal static class DateTimeExtension
	{
		public static long ToTimestamp(this DateTime dt)
		{
			var startDateTime = new DateTime(1970, 1, 1, 8, 0, 0);
			return Convert.ToInt64((dt - startDateTime).TotalSeconds);
		}
	}
}
