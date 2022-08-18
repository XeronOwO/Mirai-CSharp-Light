using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Models.Message;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning disable CS8601 // 引用类型赋值可能为 null。
#pragma warning disable CS8602 // 解引用可能出现空引用。
#pragma warning disable CS8604 // 引用类型参数可能为 null。
namespace Mirai.CSharp.Light.Models.EventArgs
{
	internal class FriendMessageEventArgs : MessageEventArgs, IFriendMessageEventArgs
	{
		public override string Type { get; set; } = "FriendMessage";

		private readonly FriendMessageSenderData sender = new();

		public override IFriendMessageSenderData Sender { get => sender; }

		public override IChatMessage[] MessageChain { get; set; } = Array.Empty<IChatMessage>();

		public static FriendMessageEventArgs Parse(JObject json)
		{
			var e = new FriendMessageEventArgs();
			ParseType(e, json);
			ParseMessageChain(e, json);
			ParseSender(e, json);
			return e;
		}

		public static void ParseSender(FriendMessageEventArgs e, JObject json)
		{
			e.sender.Id = (long)json["sender"]["id"];
			e.sender.Nickname = (string)json["sender"]["nickname"];
			e.sender.Remark = (string)json["sender"]["remark"];
		}
	}
}
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
#pragma warning restore CS8602 // 解引用可能出现空引用。
#pragma warning restore CS8604 // 引用类型参数可能为 null。
