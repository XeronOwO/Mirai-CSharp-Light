using Mirai.CSharp.Light.Exception;
using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Models.EventArgs;
using Mirai.CSharp.Light.Models.Message;
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
		/// <summary>
		/// 会话密钥
		/// </summary>
		public string SessionKey { get; }

		/// <summary>
		/// Bot基本信息
		/// </summary>
		public IBasicData BotData { get; }

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

		#region 发送临时消息

		/// <summary>
		/// 发送临时消息
		/// </summary>
		/// <param name="qq">临时会话对象QQ号</param>
		/// <param name="group">临时会话群号</param>
		/// <param name="messageChain">消息链，是一个IChatMessage构成的数组</param>
		/// <param name="quote">引用一条消息的消息ID进行回复</param>
		/// <exception cref="MiraiException"></exception>
		/// <returns>消息ID</returns>
		public int SendTempMessage(long qq, long group, IChatMessage[] messageChain, int? quote = null);

		/// <summary>
		/// 异步发送临时消息
		/// </summary>
		/// <param name="qq">临时会话对象QQ号</param>
		/// <param name="group">临时会话群号</param>
		/// <param name="messageChain">消息链，是一个IChatMessage构成的数组</param>
		/// <param name="quote">引用一条消息的消息ID进行回复</param>
		/// <returns>Task实例，其Result为消息ID</returns>
		public Task<int> SendTempMessageAsync(long qq, long group, IChatMessage[] messageChain, int? quote = null);

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

		#region 文件上传

		/// <summary>
		/// 上传图片
		/// </summary>
		/// <param name="type">上传文件的类别</param>
		/// <param name="path">文件路径（相对于MCL目录的路径，或者使用绝对路径）</param>
		/// <returns>图片消息</returns>
		public ImageMessage UploadImage(UploadType type, string path);

		/// <summary>
		/// 异步上传图片
		/// </summary>
		/// <param name="type">上传文件的类别</param>
		/// <param name="path">文件路径（相对于MCL目录的路径，或者使用绝对路径）</param>
		/// <returns>Task实例，其Result为图片消息</returns>
		public Task<ImageMessage> UploadImageAsync(UploadType type, string path);

		#endregion

		#region 通过消息ID获取消息

		/// <summary>
		/// 通过消息ID获取消息（APIVersion &gt;= 2.6.0）
		/// </summary>
		/// <param name="id">获取消息的消息ID</param>
		/// <param name="target">好友ID或群ID</param>
		/// <returns>消息事件参数</returns>
		/// <exception cref="MiraiException"></exception>
		public IMessageEventArgs GetMessage(int id, long target);

		/// <summary>
		/// 通过消息ID获取消息（APIVersion &gt;= 2.6.0）
		/// </summary>
		/// <param name="id">获取消息的消息ID</param>
		/// <param name="target">好友ID或群ID</param>
		/// <returns>Task实例，其Result为消息事件参数</returns>
		public Task<IMessageEventArgs> GetMessageAsync(int id, long target);

		/// <summary>
		/// 通过消息ID获取消息（APIVersion &lt; 2.6.0）
		/// </summary>
		/// <param name="messageId">消息ID</param>
		/// <returns>消息事件参数</returns>
		/// <exception cref="MiraiException"></exception>
		public IMessageEventArgs GetMessage(int messageId);

		/// <summary>
		/// 通过消息ID获取消息（APIVersion &lt; 2.6.0）
		/// </summary>
		/// <param name="messageId">消息ID</param>
		/// <returns>Task实例，其Result为消息事件参数</returns>
		public Task<IMessageEventArgs> GetMessageAsync(int messageId);

		#endregion
	}
}
