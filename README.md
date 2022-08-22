# Mirai-CSharp-Light
轻量化的Mirai-CSharp
# 关于
## 简介
这是一个帮助C#开发者与 [Mirai](https://github.com/mamoe/mirai) 交互的轻量化项目  
灵感源自 [Executor-Cheng的Mirai-CSharp](https://github.com/Executor-Cheng/Mirai-CSharp)  
相比于 [Mirai-CSharp](https://github.com/Executor-Cheng/Mirai-CSharp) ，Mirai-CSharp-Light更加轻量化、简洁、易于使用，而且几乎所有功能都同时支持同步与异步  
它通过调用 [Mirai-Api-Http](https://github.com/project-mirai/mirai-api-http) 提供的 Http-Api 与其交互
## 第三方库
[Newtownsoft.Json](https://www.newtonsoft.com/json)
# 开始使用
## 安装
用自己的Visual Studio编译本项目，或者在 [Release](https://github.com/q2398003522/Mirai-CSharp-Light/releases) 中直接下载
## 使用例子
[Program.cs](https://github.com/q2398003522/Mirai-CSharp-Light/blob/master/Mirai-CSharp-Light.Example/Program.cs)  
[处理好友消息](https://github.com/q2398003522/Mirai-CSharp-Light/blob/master/Mirai-CSharp-Light.Example/Example.HandleFriendMessage.cs)  
[处理群消息](https://github.com/q2398003522/Mirai-CSharp-Light/blob/master/Mirai-CSharp-Light.Example/Example.HandleGroupMessage.cs)  
[处理临时消息](https://github.com/q2398003522/Mirai-CSharp-Light/blob/master/Mirai-CSharp-Light.Example/Example.HandleTempMessage.cs)  
[处理陌生人消息](https://github.com/q2398003522/Mirai-CSharp-Light/blob/master/Mirai-CSharp-Light.Example/Example.HandleStrangerMessage.cs)  
# 开发进度
## 已实现功能
<table>
	<tr>
		<th colspan="3">功能</th>
		<th>对应的函数或接口</th>
	</tr>
	<tr>
		<td rowspan="28">接口</td>
		<td>缓存操作</td>
		<td>通过消息ID获取消息</td>
		<td>GetMessage(Async)</td>
	</tr>
	<tr>
		<td rowspan="7">获取账号信息</td>
		<td>获取好友列表</td>
		<td>GetFriendList(Async)</td>
	</tr>
	<tr>
		<td>获取群列表</td>
		<td>GetGroupList(Async)</td>
	</tr>
	<tr>
		<td>获取群成员列表</td>
		<td>GetGroupMemberList(Async)</td>
	</tr>
	<tr>
		<td>获取Bot资料</td>
		<td>GetBotProfile(Async)</td>
	</tr>
	<tr>
		<td>获取好友资料</td>
		<td>GetFriendProfile(Async)</td>
	</tr>
	<tr>
		<td>获取群成员资料</td>
		<td>GetGroupMemberProfile(Async)</td>
	</tr>
	<tr>
		<td>获取QQ用户资料</td>
		<td>GetUserProfile(Async)</td>
	</tr>
	<tr>
		<td rowspan="6">消息发送与撤回</td>
		<td>发送好友消息</td>
		<td>SendFriendMessage(Async)</td>
	</tr>
	<tr>
		<td>发送群消息</td>
		<td>SendGroupMessage(Async)</td>
	</tr>
	<tr>
		<td>发送临时会话消息</td>
		<td>SendTempMessage(Async)</td>
	</tr>
	<tr>
		<td>发送头像戳一戳消息</td>
		<td>SendNudge(Async)</td>
	</tr>
	<tr>
		<td>撤回消息</td>
		<td>RevokeMessage(Async)</td>
	</tr>
	<tr>
		<td>获取漫游消息</td>
		<td>GetRoamingMessages(Async)</td>
	</tr>
	<tr>
		<td>账号管理</td>
		<td>删除好友</td>
		<td>DeleteFriend(Async)</td>
	</tr>
	<tr>
		<td rowspan="12">群管理</td>
		<td>禁言群成员</td>
		<td>Mute(Async)</td>
	</tr>
	<tr>
		<td>解除群成员禁言</td>
		<td>Unmute(Async)</td>
	</tr>
	<tr>
		<td>移除群成员</td>
		<td>Kick(Async)</td>
	</tr>
	<tr>
		<td>退出群聊</td>
		<td>Quit(Async)</td>
	</tr>
	<tr>
		<td>全体禁言</td>
		<td>MuteAll(Async)</td>
	</tr>
	<tr>
		<td>解除全体禁言</td>
		<td>UnmuteAll(Async)</td>
	</tr>
	<tr>
		<td>设置群精华消息</td>
		<td>SetEssence(Async)</td>
	</tr>
	<tr>
		<td>获取群设置</td>
		<td>GetGroupConfig(Async)</td>
	</tr>
	<tr>
		<td>修改群设置</td>
		<td>SetGroupConfig(Async)</td>
	</tr>
	<tr>
		<td>获取群员设置</td>
		<td>GetMemberInfo(Async)</td>
	</tr>
	<tr>
		<td>修改群员设置</td>
		<td>SetMemberInfo(Async)</td>
	</tr>
	<tr>
		<td>修改群员管理员</td>
		<td>SetMemberAdmin(Async)</td>
	</tr>
	<tr>
		<td rowspan="1">多媒体内容上传</td>
		<td>图片文件上传</td>
		<td>UploadImage(Async)</td>
	</tr>
	<tr>
		<td rowspan="11">事件</td>
		<td rowspan="4">消息事件</td>
		<td>好友消息事件</td>
		<td>IFriendMessageHandler</td>
	</tr>
	<tr>
		<td>群消息事件</td>
		<td>IGroupMessageHandler</td>
	</tr>
	<tr>
		<td>临时消息事件</td>
		<td>ITempMessageHandler</td>
	</tr>
	<tr>
		<td>陌生人消息事件</td>
		<td>IStrangerMessageHandler</td>
	</tr>
	<tr>
		<td rowspan="5">Bot自身事件</td>
		<td>Bot登录成功</td>
		<td>IBotOnlineEventHandler</td>
	</tr>
	<tr>
		<td>Bot主动离线</td>
		<td>IBotOfflineEventActiveHandler</td>
	</tr>
	<tr>
		<td>Bot被挤下线</td>
		<td>IBotOfflineEventForceHandler</td>
	</tr>
	<tr>
		<td>Bot被服务器断开或因网络问题而掉线</td>
		<td>IBotOfflineEventDroppedHandler</td>
	</tr>
	<tr>
		<td>Bot主动重新登录</td>
		<td>IBotReloginEventHandler</td>
	</tr>
	<tr>
		<td rowspan="2">好友事件</td>
		<td>好友输入状态改变</td>
		<td>IFriendInputStatusChangedEventHandler</td>
	</tr>
	<tr>
		<td>好友昵称改变</td>
		<td>IFriendNickChangedEventHandler</td>
	</tr>
</table>
