using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
	internal static class TimestampExtension
	{
		public static DateTime ToDateTime(this long timestamp)
		{
			long ticks = timestamp * 10000000;
			var beginTime = new DateTime(1970, 1, 1, 8, 0, 0);
			long beginTicks = beginTime.Ticks;
			long totalTicks = beginTicks + ticks;
			return new DateTime(totalTicks);
		}
	}
}
