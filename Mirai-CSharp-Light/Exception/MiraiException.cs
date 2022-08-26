using Mirai.CSharp.Light.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Exception
{
	/// <summary>
	/// Mirai异常
	/// </summary>
	public class MiraiException : System.Exception
	{
		/// <summary>
		/// 普通异常
		/// </summary>
		/// <param name="name">Logger名称</param>
		/// <param name="message">错误信息</param>
		public MiraiException(string name, string message) : base(message)
		{
			MiraiCSharpLightLogger.GetLogger(name).Error(message);
			Console.ForegroundColor = ConsoleColor.Red;
		}

		private static string GetErrorMessage(int id) => id switch
		{
			0 => "正常",
			1 => "错误的verify key",
			2 => "指定的Bot不存在",
			3 => "Session失效或不存在",
			4 => "Session未认证(未激活)",
			5 => "发送消息目标不存在(指定对象不存在)",
			6 => "指定文件不存在，出现于发送本地图片",
			10 => "无操作权限，指Bot没有对应操作的限权",
			20 => "Bot被禁言，指Bot当前无法向指定群发送消息",
			30 => "消息过长",
			400 => "错误的访问，如参数错误等",
			_ => "未知错误",
		};

		/// <summary>
		/// 状态码异常
		/// </summary>
		/// <param name="name">Logger名称</param>
		/// <param name="message">异常信息</param>
		/// <param name="id">错误id</param>
		public MiraiException(string name, string message, int id) : base($"{message}：{GetErrorMessage(id)}")
		{
			MiraiCSharpLightLogger.GetLogger(name).Error($"{message}：{GetErrorMessage(id)}");
			Console.ForegroundColor = ConsoleColor.Red;
		}

		/// <summary>
		/// 状态码异常拓展
		/// </summary>
		/// <param name="name">Logger名称</param>
		/// <param name="message">异常信息</param>
		/// <param name="id">错误id</param>
		/// <param name="extraMessage">额外异常信息</param>
		public MiraiException(string name, string message, int id, string extraMessage) : base($"{message}：{GetErrorMessage(id)}（{extraMessage}）")
		{
			MiraiCSharpLightLogger.GetLogger(name).Error($"{message}：{GetErrorMessage(id)}（{extraMessage}）");
			Console.ForegroundColor = ConsoleColor.Red;
		}
	}
}
