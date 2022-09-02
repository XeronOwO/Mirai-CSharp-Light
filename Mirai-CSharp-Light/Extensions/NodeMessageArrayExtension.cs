using Mirai.CSharp.Light.Exception;
using Mirai.CSharp.Light.Models;
using Mirai.CSharp.Light.Models.Message;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Extensions
{
	internal static class NodeMessageArrayExtension
	{
		public static JArray ToJArray(this NodeMessage[] nodeList)
		{
			var array = new JArray();
			foreach (var node in nodeList)
			{
				array.Add(node.ToJObject());
			}
			return array;
		}
	}
}
