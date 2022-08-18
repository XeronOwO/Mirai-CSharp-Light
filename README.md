# Mirai-CSharp-Light
轻量化的Mirai-CSharp
# 关于
这是一个帮助C#开发者与 [Mirai](https://github.com/mamoe/mirai) 交互的轻量化项目  
灵感源自 [Executor-Cheng的Mirai-CSharp](https://github.com/Executor-Cheng/Mirai-CSharp)  
相比于 [Mirai-CSharp](https://github.com/Executor-Cheng/Mirai-CSharp) ，Mirai-CSharp-Light更加轻量化、易于使用，而且几乎所有功能都同时支持同步与异步  
它通过调用 [Mirai-Api-Http](https://github.com/project-mirai/mirai-api-http) 提供的 Http-Api 与其交互
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
		<th>对应的函数或类</th>
	</tr>
	<tr>
		<td rowspan="9">接口</td>
		<td>缓存操作</td>
		<td>通过消息ID获取消息</td>
		<td>GetMessage(Async)</td>
	</tr>
	<tr>
		<td rowspan="3">获取账号信息</td>
		<td>获取好友列表</td>
		<td>GetFriendList(Async)</td>
	</tr>
	<tr>
		<td>获取群列表</td>
		<td>GetGroupList(Async)</td>
	</tr>
	<tr>
		<td>获取Bot资料</td>
		<td>GetBotProfile(Async)</td>
	</tr>
	<tr>
		<td rowspan="4">消息发送与撤回</td>
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
		<td>撤回消息</td>
		<td>RevokeMessage(Async)</td>
	</tr>
	<tr>
		<td rowspan="1">文件操作</td>
		<td>上传图片</td>
		<td>UploadImage(Async)</td>
	</tr>
	<tr>
		<td colspan="2" rowspan="4">事件</td>
		<td>好友消息接口</td>
		<td>IFriendMessageHandler</td>
	</tr>
	<tr>
		<td>群消息接口</td>
		<td>IGroupMessageHandler</td>
	</tr>
	<tr>
		<td>临时消息接口</td>
		<td>ITempMessageHandler</td>
	</tr>
	<tr>
		<td>陌生人消息接口</td>
		<td>IStrangerMessageHandler</td>
	</tr>
</table>
