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
    internal class GroupMessageEventArgs : MessageEventArgs, IGroupMessageEventArgs
	{
		public override string Type { get; set; } = "GroupMessage";

		private readonly GroupMessageSenderData sender = new();

		public override IGroupMessageSenderData Sender { get => sender; }

		public override IChatMessage[] MessageChain { get; set; } = Array.Empty<IChatMessage>();

		public static GroupMessageEventArgs Parse(JObject json)
		{
			var e = new GroupMessageEventArgs();
			ParseType(e, json);
			ParseMessageChain(e, json);
			ParseSender(e, json);
			return e;
		}

		public static void ParseSender(GroupMessageEventArgs e, JObject json)
		{
			e.sender.Id = (long)json["sender"]["id"];
			e.sender.MemberName = (string)json["sender"]["memberName"];
			e.sender.SpecialTitle = (string)json["sender"]["specialTitle"];
			e.sender.Permission = ((string)json["sender"]["permission"]).ToGroupPermission();
			e.sender.JoinTimestamp = (long)json["sender"]["joinTimestamp"];
			e.sender.JoinDateTime = GetDateTimeFromUnixTimeStamp(e.sender.JoinTimestamp);
			e.sender.LastSpeakTimestamp = (long)json["sender"]["lastSpeakTimestamp"];
			e.sender.LastSpeakDateTime = GetDateTimeFromUnixTimeStamp(e.sender.LastSpeakTimestamp);
			e.sender.MuteTimeRemaining = (int)json["sender"]["muteTimeRemaining"];
			e.sender.Group_.Id = (long)json["sender"]["group"]["id"];
			e.sender.Group_.Name = (string)json["sender"]["group"]["name"];
			e.sender.Group_.Permission = ((string)json["sender"]["group"]["permission"]).ToGroupPermission();
		}
	}
}
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
#pragma warning restore CS8602 // 解引用可能出现空引用。
#pragma warning restore CS8604 // 引用类型参数可能为 null。
