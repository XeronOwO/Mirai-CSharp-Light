using Mirai.CSharp.Light.Exception;
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
		/// <param name="id">消息ID</param>
		/// <returns>消息事件参数</returns>
		/// <exception cref="MiraiException"></exception>
		public CommonMessageData GetMessage(int id);

		/// <summary>
		/// 通过消息ID获取消息（APIVersion &lt; 2.6.0）
		/// </summary>
		/// <param name="id">消息ID</param>
		/// <returns>Task实例，其Result为消息事件参数</returns>
		public Task<CommonMessageData> GetMessageAsync(int id);

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
		/// <exception cref="MiraiException"></exception>
		/// <returns>消息链数组</returns>
		public CommonMessageData[] GetRoamingMessages(int timeStart, int timeEnd, long target);

		/// <summary>
		/// 异步获取漫游消息
		/// </summary>
		/// <param name="timeStart">起始时间, UTC+8 时间戳, 单位为秒. 可以为 0, 即表示从可以获取的最早的消息起. 负数将会被看是 0.</param>
		/// <param name="timeEnd">结束时间, UTC+8 时间戳, 单位为秒. 可以为 Long.MAX_VALUE, 即表示到可以获取的最晚的消息为止. 低于 timeStart 的值将会被看作是 timeStart 的值.</param>
		/// <param name="target">漫游消息对象，好友id，目前仅支持好友漫游消息</param>
		/// <returns>Task实例，其Result为消息链数组</returns>
		public Task<CommonMessageData[]> GetRoamingMessagesAsync(int timeStart, int timeEnd, long target);

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

		#region 账号管理

		#region 删除好友

		/// <summary>
		/// 删除好友
		/// </summary>
		/// <param name="target">删除好友的QQ号码</param>
		/// <exception cref="MiraiException"></exception>
		public void DeleteFriend(long target);

		/// <summary>
		/// 异步删除好友
		/// </summary>
		/// <param name="target">删除好友的QQ号码</param>
		/// <returns>Task实例</returns>
		public Task DeleteFriendAsync(long target);

		#endregion

		#endregion

		#region 群管理

		#region 禁言群成员

		/// <summary>
		/// 禁言群成员
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">指定群员QQ号</param>
		/// <param name="time">禁言时长，单位为秒，最多30天，默认为0</param>
		/// <exception cref="MiraiException"></exception>
		public void Mute(long target, long memberId, int time);

		/// <summary>
		/// 异步禁言群成员
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">指定群员QQ号</param>
		/// <param name="time">禁言时长，单位为秒，最多30天，默认为0</param>
		/// <returns>Task实例</returns>
		public Task MuteAsync(long target, long memberId, int time);

		/// <summary>
		/// 禁言群成员
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">指定群员QQ号</param>
		/// <param name="time">禁言时长，单位为秒，最多30天，默认为0</param>
		/// <exception cref="MiraiException"></exception>
		public void Mute(long target, long memberId, TimeSpan time);

		/// <summary>
		/// 异步禁言群成员
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">指定群员QQ号</param>
		/// <param name="time">禁言时长，单位为秒，最多30天，默认为0</param>
		/// <returns>Task实例</returns>
		public Task MuteAsync(long target, long memberId, TimeSpan time);

		#endregion

		#region 解除群成员禁言

		/// <summary>
		/// 解除群成员禁言
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">指定群员QQ号</param>
		/// <exception cref="MiraiException"></exception>
		public void Unmute(long target, long memberId);

		/// <summary>
		/// 异步解除群成员禁言
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">指定群员QQ号</param>
		/// <returns>Task实例</returns>
		public Task UnmuteAsync(long target, long memberId);

		#endregion

		#region 移除群成员

		/// <summary>
		/// 移除群成员
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">指定群员QQ号</param>
		/// <param name="msg">信息</param>
		/// <exception cref="MiraiException"></exception>
		public void Kick(long target, long memberId, string msg = "");

		/// <summary>
		/// 异步移除群成员
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">指定群员QQ号</param>
		/// <param name="msg">信息</param>
		/// <returns>Task实例</returns>
		public Task KickAsync(long target, long memberId, string msg = "");

		#endregion

		#region 退出群聊

		/// <summary>
		/// 退出群聊
		/// </summary>
		/// <param name="target">退出的群号</param>
		/// <remarks>bot为该群群主时退出失败并返回code 10(无操作权限)</remarks>
		/// <exception cref="MiraiException"></exception>
		public void Quit(long target);

		/// <summary>
		/// 异步退出群聊
		/// </summary>
		/// <param name="target">退出的群号</param>
		/// <remarks>bot为该群群主时退出失败并返回code 10(无操作权限)</remarks>
		/// <returns>Task实例</returns>
		public Task QuitAsync(long target);

		#endregion

		#region 全体禁言

		/// <summary>
		/// 全体禁言
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <exception cref="MiraiException"></exception>
		public void MuteAll(long target);

		/// <summary>
		/// 异步全体禁言
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <returns>Task实例</returns>
		public Task MuteAllAsync(long target);

		#endregion

		#region 解除全体禁言

		/// <summary>
		/// 解除全体禁言
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <exception cref="MiraiException"></exception>
		public void UnmuteAll(long target);

		/// <summary>
		/// 异步解除全体禁言
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <returns>Task实例</returns>
		public Task UnmuteAllAsync(long target);

		#endregion

		#region 设置群精华消息

		/// <summary>
		/// 设置群精华消息（APIVersion &gt;= 2.6.0）
		/// </summary>
		/// <param name="messageId">精华消息的messageId</param>
		/// <param name="target">群ID</param>
		/// <exception cref="MiraiException"></exception>
		public void SetEssence(int messageId, long target);

		/// <summary>
		/// 异步设置群精华消息（APIVersion &gt;= 2.6.0）
		/// </summary>
		/// <param name="messageId">获取消息的消息ID</param>
		/// <param name="target">好友ID或群ID</param>
		/// <returns>Task实例</returns>
		public Task SetEssenceAsync(int messageId, long target);

		/// <summary>
		/// 设置群精华消息（APIVersion &lt; 2.6.0）
		/// </summary>
		/// <param name="target">消息ID</param>
		/// <exception cref="MiraiException"></exception>
		public void SetEssence(int target);

		/// <summary>
		/// 异步设置群精华消息（APIVersion &lt; 2.6.0）
		/// </summary>
		/// <param name="target">消息ID</param>
		/// <returns>Task实例</returns>
		public Task SetEssenceAsync(int target);

		#endregion

		#region 获取群设置

		/// <summary>
		/// 获取群设置
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <returns>群设置</returns>
		public GroupConfigData GetGroupConfig(long target);

		/// <summary>
		/// 异步获取群设置
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <returns>Task实例，其Result为群设置</returns>
		public Task<GroupConfigData> GetGroupConfigAsync(long target);

		#endregion

		#region 修改群设置

		/// <summary>
		/// 修改群设置
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="config">群设置</param>
		public void SetGroupConfig(long target, GroupConfigData config);

		/// <summary>
		/// 异步修改群设置
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="config">群设置</param>
		/// <returns>Task实例</returns>
		public Task SetGroupConfigAsync(long target, GroupConfigData config);

		#endregion

		#region 获取群员设置

		/// <summary>
		/// 获取群员设置
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">群员QQ号</param>
		/// <returns>群员设置</returns>
		public IGroupMemberData GetMemberInfo(long target, long memberId);

		/// <summary>
		/// 异步获取群员设置
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">群员QQ号</param>
		/// <returns>Task实例，其Result为获取群员设置</returns>
		public Task<IGroupMemberData> GetMemberInfoAsync(long target, long memberId);

		#endregion

		#region 修改群员设置

		/// <summary>
		/// 修改群员设置
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">群员QQ号</param>
		/// <param name="config">设置</param>
		public void SetMemberInfo(long target, long memberId, GroupMemberDataSet config);

		/// <summary>
		/// 异步修改群员设置
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">群员QQ号</param>
		/// <param name="config">设置</param>
		/// <returns>Task实例</returns>
		public Task SetMemberInfoAsync(long target, long memberId, GroupMemberDataSet config);

		#endregion

		#region 修改群员管理员

		/// <summary>
		/// 修改群员管理员
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">群员QQ号</param>
		/// <param name="assign">是否设置为管理员</param>
		public void SetMemberAdmin(long target, long memberId, bool assign);

		/// <summary>
		/// 异步修改群员管理员
		/// </summary>
		/// <param name="target">指定群的群号</param>
		/// <param name="memberId">群员QQ号</param>
		/// <param name="assign">是否设置为管理员</param>
		/// <returns>Task实例</returns>
		public Task SetMemberAdminAsync(long target, long memberId, bool assign);

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

		#region 事件处理

		#region 添加好友申请

		/// <summary>
		/// 处理添加好友申请
		/// </summary>
		/// <param name="e">添加好友申请事件信息</param>
		/// <param name="operate">添加好友申请处理方式</param>
		/// <param name="message">回复的信息</param>
		public void HandleNewFriendRequest(INewFriendRequestEventData e, NewFriendOperateType operate, string message);

		/// <summary>
		/// 异步处理添加好友申请
		/// </summary>
		/// <param name="e">添加好友申请事件信息</param>
		/// <param name="operate">添加好友申请处理方式</param>
		/// <param name="message">回复的信息</param>
		/// <returns>Task实例</returns>
		public Task HandleNewFriendRequestAsync(INewFriendRequestEventData e, NewFriendOperateType operate, string message);

		#endregion

		#region 用户入群申请

		/// <summary>
		/// 处理用户入群申请（Bot需要有管理员权限）
		/// </summary>
		/// <param name="e">用户入群申请事件信息</param>
		/// <param name="operate">用户入群申请处理方式</param>
		/// <param name="message">回复的信息</param>
		public void HandleMemberJoinRequest(IMemberJoinRequestEventData e, MemberJoinOperateType operate, string message);

		/// <summary>
		/// 异步处理用户入群申请（Bot需要有管理员权限）
		/// </summary>
		/// <param name="e">用户入群申请事件信息</param>
		/// <param name="operate">用户入群申请处理方式</param>
		/// <param name="message">回复的信息</param>
		/// <returns>Task实例</returns>
		public Task HandleMemberJoinRequestAsync(IMemberJoinRequestEventData e, MemberJoinOperateType operate, string message);

		#endregion

		#region Bot被邀请入群申请

		/// <summary>
		/// 处理Bot被邀请入群申请
		/// </summary>
		/// <param name="e">Bot被邀请入群申请事件信息</param>
		/// <param name="operate">Bot被邀请入群申请处理方式</param>
		/// <param name="message">回复的信息</param>
		public void HandleBotInvitedJoinGroupRequest(IBotInvitedJoinGroupRequestEventData e, BotInvitedJoinGroupOperateType operate, string message);

		/// <summary>
		/// 异步Bot被邀请入群申请
		/// </summary>
		/// <param name="e">Bot被邀请入群申请事件信息</param>
		/// <param name="operate">Bot被邀请入群申请处理方式</param>
		/// <param name="message">回复的信息</param>
		/// <returns>Task实例</returns>
		public Task HandleBotInvitedJoinGroupRequestAsync(IBotInvitedJoinGroupRequestEventData e, BotInvitedJoinGroupOperateType operate, string message);

		#endregion

		#endregion

		#endregion
	}
}
