using Mirai.CSharp.Light.Exception;
using Mirai.CSharp.Light.Extensions;
using Mirai.CSharp.Light.Models;
using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Models.Message;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Session
{
	/// <summary>
	/// Mirai会话接口
	/// </summary>
	public interface IMiraiSession
	{
		#region 其它成员

		/// <summary>
		/// 会话密钥
		/// </summary>
		public string SessionKey { get; }

		/// <summary>
		/// Bot基本信息
		/// </summary>
		public IUserData BotData { get; }

		#endregion

		#region 接口

		#region 缓存操作

		#region 通过messageId获取消息

		/// <summary>
		/// 通过消息ID获取消息（APIVersion &gt;= 2.6.0）
		/// </summary>
		/// <param name="id">获取消息的消息ID</param>
		/// <param name="target">好友ID或群ID</param>
		/// <returns>消息事件参数</returns>
		/// <exception cref="MiraiException"></exception>
		public CommonMessageData GetMessage(int id, long target);

		/// <summary>
		/// 通过消息ID获取消息（APIVersion &gt;= 2.6.0）
		/// </summary>
		/// <param name="id">获取消息的消息ID</param>
		/// <param name="target">好友ID或群ID</param>
		/// <returns>Task实例，其Result为消息事件参数</returns>
		public Task<CommonMessageData> GetMessageAsync(int id, long target);

		/// <summary>
		/// 通过消息ID获取消息（APIVersion &lt; 2.6.0）
		/// </summary>
		/// <param name="messageId">消息ID</param>
		/// <returns>消息事件参数</returns>
		/// <exception cref="MiraiException"></exception>
		public CommonMessageData GetMessage(int messageId);

		/// <summary>
		/// 通过消息ID获取消息（APIVersion &lt; 2.6.0）
		/// </summary>
		/// <param name="messageId">消息ID</param>
		/// <returns>Task实例，其Result为消息事件参数</returns>
		public Task<CommonMessageData> GetMessageAsync(int messageId);

		#endregion

		#endregion

		#region 获取账号信息

		#region 获取好友列表

		/// <summary>
		/// 获取好友列表
		/// </summary>
		/// <returns>好友列表</returns>
		public IUserData[] GetFriendList();

		/// <summary>
		/// 异步获取好友列表
		/// </summary>
		/// <returns>Task实例，其Result为好友列表</returns>
		public Task<IUserData[]> GetFriendListAsync();

		#endregion

		#region 获取群列表

		/// <summary>
		/// 获取群列表
		/// </summary>
		/// <returns>群列表</returns>
		public IGroupData[] GetGroupList();

		/// <summary>
		/// 异步获取群列表
		/// </summary>
		/// <returns>Task实例，其Result为群列表</returns>
		public Task<IGroupData[]> GetGroupListAsync();

		#endregion

		#region 获取群成员列表

		/// <summary>
		/// 获取群成员列表
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <returns>群成员列表</returns>
		public IGroupMemberData[] GetGroupMemberList(long target);

		/// <summary>
		/// 异步获取群成员列表
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <returns>Task实例，其Result为群成员列表</returns>
		public Task<IGroupMemberData[]> GetGroupMemberListAsync(long target);

		#endregion

		#region 获取Bot资料

		/// <summary>
		/// 获取Bot资料
		/// </summary>
		/// <returns>Bot资料</returns>
		public IUserProfileData GetBotProfile();

		/// <summary>
		/// 异步获取Bot资料
		/// </summary>
		/// <returns>Task实例，其Result为Bot资料</returns>
		public Task<IUserProfileData> GetBotProfileAsync();

		#endregion

		#region 获取好友资料

		/// <summary>
		/// 获取好友资料
		/// </summary>
		/// <param name="target">指定好友账号</param>
		/// <returns>好友资料</returns>
		public IUserProfileData GetFriendProfile(long target);

		/// <summary>
		/// 异步获取好友资料
		/// </summary>
		/// <param name="target">指定好友账号</param>
		/// <returns>Task实例，其Result为好友资料</returns>
		public Task<IUserProfileData> GetFriendProfileAsync(long target);

		#endregion

		#region 获取群成员资料

		/// <summary>
		/// 获取群成员资料
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">群成员QQ号码</param>
		/// <returns>群成员资料</returns>
		public IUserProfileData GetGroupMemberProfile(long target, long memberId);

		/// <summary>
		/// 异步获取群成员资料
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">群成员QQ号码</param>
		/// <returns>Task实例，其Result为群成员资料</returns>
		public Task<IUserProfileData> GetGroupMemberProfileAsync(long target, long memberId);

		#endregion

		#region 获取QQ用户资料

		/// <summary>
		/// 获取QQ用户资料
		/// </summary>
		/// <param name="target">要查询的QQ号码</param>
		/// <returns>QQ用户资料</returns>
		public IUserProfileData GetUserProfile(long target);

		/// <summary>
		/// 异步获取QQ用户资料
		/// </summary>
		/// <param name="target">要查询的QQ号码</param>
		/// <returns>Task实例，其Result为QQ用户资料</returns>
		public Task<IUserProfileData> GetUserProfileAsync(long target);

		#endregion

		#endregion

		#region 消息发送与撤回

		#region 发送好友消息

		/// <summary>
		/// 发送好友消息
		/// </summary>
		/// <param name="target">发送消息目标好友的QQ号</param>
		/// <param name="messageChain">消息链，是一个IChatMessage构成的数组</param>
		/// <param name="quote">引用一条消息的消息ID进行回复</param>
		/// <exception cref="MiraiException"></exception>
		/// <returns>消息ID</returns>
		public int SendFriendMessage(long target, IChatMessage[] messageChain, int? quote = null);

		/// <summary>
		/// 异步发送好友消息
		/// </summary>
		/// <param name="target">发送消息目标好友的QQ号</param>
		/// <param name="messageChain">消息链，是一个IChatMessage构成的数组</param>
		/// <param name="quote">引用一条消息的消息ID进行回复</param>
		/// <returns>Task实例，其Result为消息ID</returns>
		public Task<int> SendFriendMessageAsync(long target, IChatMessage[] messageChain, int? quote = null);

		#endregion

		#region 发送群消息

		/// <summary>
		/// 发送群消息
		/// </summary>
		/// <param name="target">发送消息目标群的群号</param>
		/// <param name="messageChain">消息链，是一个IChatMessage构成的数组</param>
		/// <param name="quote">引用一条消息的消息ID进行回复</param>
		/// <exception cref="MiraiException"></exception>
		/// <returns>消息ID</returns>
		public int SendGroupMessage(long target, IChatMessage[] messageChain, int? quote = null);

		/// <summary>
		/// 异步发送群消息
		/// </summary>
		/// <param name="target">目标群</param>
		/// <param name="messageChain">消息链</param>
		/// <param name="quote">引用一条消息的消息ID进行回复</param>
		/// <returns>Task实例，其Result为消息ID</returns>
		public Task<int> SendGroupMessageAsync(long target, IChatMessage[] messageChain, int? quote = null);

		#endregion

		#region 发送临时会话消息

		/// <summary>
		/// 发送临时会话消息
		/// </summary>
		/// <param name="qq">临时会话对象QQ号</param>
		/// <param name="group">临时会话群号</param>
		/// <param name="messageChain">消息链，是一个IChatMessage构成的数组</param>
		/// <param name="quote">引用一条消息的消息ID进行回复</param>
		/// <exception cref="MiraiException"></exception>
		/// <returns>消息ID</returns>
		public int SendTempMessage(long qq, long group, IChatMessage[] messageChain, int? quote = null);

		/// <summary>
		/// 异步发送临时会话消息
		/// </summary>
		/// <param name="qq">临时会话对象QQ号</param>
		/// <param name="group">临时会话群号</param>
		/// <param name="messageChain">消息链，是一个IChatMessage构成的数组</param>
		/// <param name="quote">引用一条消息的消息ID进行回复</param>
		/// <returns>Task实例，其Result为消息ID</returns>
		public Task<int> SendTempMessageAsync(long qq, long group, IChatMessage[] messageChain, int? quote = null);

		#endregion

		#region 发送头像戳一戳消息

		/// <summary>
		/// 发送头像戳一戳消息
		/// </summary>
		/// <param name="target">戳一戳的目标, QQ号, 可以为 Bot QQ号</param>
		/// <param name="subject">戳一戳接受主体(上下文), 戳一戳信息会发送至该主体, 为群号/好友QQ号</param>
		/// <param name="kind">上下文类型, 可选值 Friend, Group, Stranger</param>
		/// <exception cref="MiraiException"></exception>
		/// <returns>消息ID</returns>
		public void SendNudge(long target, long subject, ContextType kind);

		/// <summary>
		/// 异步发送头像戳一戳消息
		/// </summary>
		/// <param name="target">戳一戳的目标, QQ号, 可以为 Bot QQ号</param>
		/// <param name="subject">戳一戳接受主体(上下文), 戳一戳信息会发送至该主体, 为群号/好友QQ号</param>
		/// <param name="kind">上下文类型, 可选值 Friend, Group, Stranger</param>
		/// <returns>Task实例</returns>
		public Task SendNudgeAsync(long target, long subject, ContextType kind);

		#endregion

		#region 撤回消息

		/// <summary>
		/// 撤回消息（APIVersion &gt;= 2.6.0）
		/// </summary>
		/// <param name="messageId">需要撤回的消息的消息ID</param>
		/// <param name="target">好友ID或群ID</param>
		/// <exception cref="MiraiException"></exception>
		public void RevokeMessage(int messageId, long target);

		/// <summary>
		/// 异步撤回消息（APIVersion &gt;= 2.6.0）
		/// </summary>
		/// <param name="messageId">需要撤回的消息的消息ID</param>
		/// <param name="target">好友ID或群ID</param>
		/// <returns>Task实例</returns>
		public Task RevokeMessageAsync(int messageId, long target);

		/// <summary>
		/// 撤回消息（APIVersion &lt; 2.6.0）
		/// </summary>
		/// <param name="messageId">需要撤回的消息的消息ID</param>
		/// <exception cref="MiraiException"></exception>
		public void RevokeMessage(int messageId);

		/// <summary>
		/// 异步撤回消息（APIVersion &lt; 2.6.0）
		/// </summary>
		/// <param name="messageId">需要撤回的消息的消息ID</param>
		/// <returns>Task实例</returns>
		public Task RevokeMessageAsync(int messageId);

		#endregion

		#region 获取漫游消息

		/// <summary>
		/// 获取漫游消息
		/// </summary>
		/// <param name="timeStart">起始时间, UTC+8 时间戳, 单位为秒. 可以为 0, 即表示从可以获取的最早的消息起. 负数将会被看是 0.</param>
		/// <param name="timeEnd">结束时间, UTC+8 时间戳, 单位为秒. 可以为 Long.MAX_VALUE, 即表示到可以获取的最晚的消息为止. 低于 timeStart 的值将会被看作是 timeStart 的值.</param>
		/// <param name="target">漫游消息对象，好友id，目前仅支持好友漫游消息</param>
		/// <returns>消息链数组</returns>
		public CommonMessageData[] GetRoamingMessages(long timeStart, long timeEnd, long target);

		/// <summary>
		/// 异步获取漫游消息
		/// </summary>
		/// <param name="timeStart">起始时间, UTC+8 时间戳, 单位为秒. 可以为 0, 即表示从可以获取的最早的消息起. 负数将会被看是 0.</param>
		/// <param name="timeEnd">结束时间, UTC+8 时间戳, 单位为秒. 可以为 Long.MAX_VALUE, 即表示到可以获取的最晚的消息为止. 低于 timeStart 的值将会被看作是 timeStart 的值.</param>
		/// <param name="target">漫游消息对象，好友id，目前仅支持好友漫游消息</param>
		/// <returns>Task实例，其Result为消息链数组</returns>
		public Task<CommonMessageData[]> GetRoamingMessagesAsync(long timeStart, long timeEnd, long target);

		/// <summary>
		/// 获取漫游消息
		/// </summary>
		/// <param name="timeStart">起始时间</param>
		/// <param name="timeEnd">结束时间</param>
		/// <param name="target">漫游消息对象，好友id，目前仅支持好友漫游消息</param>
		/// <returns>消息链数组</returns>
		public CommonMessageData[] GetRoamingMessages(DateTime timeStart, DateTime timeEnd, long target);

		/// <summary>
		/// 异步获取漫游消息
		/// </summary>
		/// <param name="timeStart">起始时间</param>
		/// <param name="timeEnd">结束时间</param>
		/// <param name="target">漫游消息对象，好友id，目前仅支持好友漫游消息</param>
		/// <returns>Task实例，其Result为消息链数组</returns>
		public Task<CommonMessageData[]> GetRoamingMessagesAsync(DateTime timeStart, DateTime timeEnd, long target);

		#endregion

		#endregion

		#region 多媒体内容上传

		#region 图片文件上传

		/// <summary>
		/// 上传图片
		/// </summary>
		/// <param name="type">上传文件的类别</param>
		/// <param name="path">文件路径（相对于MCL目录的路径，或者使用绝对路径）</param>
		/// <returns>图片消息</returns>
		public ImageMessage UploadImage(ContextType type, string path);

		/// <summary>
		/// 异步上传图片
		/// </summary>
		/// <param name="type">上传文件的类别</param>
		/// <param name="path">文件路径（相对于MCL目录的路径，或者使用绝对路径）</param>
		/// <returns>Task实例，其Result为图片消息</returns>
		public Task<ImageMessage> UploadImageAsync(ContextType type, string path);

		#endregion

		#endregion

		#endregion
	}
}
