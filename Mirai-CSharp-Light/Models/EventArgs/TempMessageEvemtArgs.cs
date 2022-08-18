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
	}
}
