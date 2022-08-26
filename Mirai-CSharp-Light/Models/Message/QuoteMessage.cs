using Mirai.CSharp.Light.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Message
{
	/// <summary>
	/// At消息
	/// </summary>
	public class QuoteMessage : IChatMessage
	{
		/// <inheritdoc/>
		public string Type { get; } = "Quote";

		/// <summary>
		/// 源数据
		/// </summary>
		public JObject Data
		{
			get => new()
			{
				["type"] = Type,
				["id"] = Id,
				["groupId"] = GroupId,
				["senderId"] = SenderId,
				["targetId"] = TargetId,
				["origin"] = Origin.ToJArray(),
			};
		}

		/// <summary>
		/// 被引用回复的原消息的messageId
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 被引用回复的原消息所接收的群号，当为好友消息时为0
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 被引用回复的原消息的发送者的QQ号
		/// </summary>
		public long SenderId { get; set; }

		/// <summary>
		/// 被引用回复的原消息的接收者者的QQ号（或群号）
		/// </summary>
		public long TargetId { get; set; }

		/// <summary>
		/// 被引用回复的原消息的消息链对象
		/// </summary>
		public IChatMessage[] Origin { get; set; }

		/// <summary>
		/// 构造引用消息
		/// </summary>
		/// <param name="id">被引用回复的原消息的messageId</param>
		/// <param name="groupId">被引用回复的原消息所接收的群号，当为好友消息时为0</param>
		/// <param name="senderId">被引用回复的原消息的发送者的QQ号</param>
		/// <param name="targetId">被引用回复的原消息的接收者者的QQ号（或群号）</param>
		/// <param name="origin">被引用回复的原消息的消息链对象</param>
		public QuoteMessage(int id, long groupId, long senderId, long targetId, IChatMessage[] origin)
		{
			Id = id;
			GroupId = groupId;
			SenderId = senderId;
			TargetId = targetId;
			Origin = origin;
		}
	}
}
