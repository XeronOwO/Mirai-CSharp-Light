using Mirai.CSharp.Light.Models.Message;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
	internal static class IChatMessageArrayExtension
	{
		public static JArray ToJArray(this IChatMessage[] chain)
		{
			var array = new JArray();
			foreach (var item in chain)
			{
				array.Add(item.Data);
			}
			return array;
		}
	}
}
