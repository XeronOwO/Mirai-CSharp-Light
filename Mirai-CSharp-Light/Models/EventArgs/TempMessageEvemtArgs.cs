using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Models.Message;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.EventArgs
{
    internal class TempMessageEventArgs : GroupMessageEventArgs, ITempMessageEventArgs
	{
		public override string Type { get; set; } = "TempMessage";

		public new static TempMessageEventArgs Parse(JObject json)
		{
			var e = new TempMessageEventArgs();
			ParseType(e, json);
			ParseMessageChain(e, json);
			ParseSender(e, json);
			return e;
		}
	}
}
