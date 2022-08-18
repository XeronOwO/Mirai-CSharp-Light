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
		/// Mirai异常的构造函数
		/// </summary>
		/// <param name="id">状态码</param>
		public MiraiException(int id) : base(
			id switch
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
			})
		{
		}

		/// <summary>
		/// Mirai异常的构造函数
		/// </summary>
		/// <param name="id">状态码</param>
		/// <param name="extraMessage">额外信息</param>
		public MiraiException(int id, string extraMessage) : base(
			id switch
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
			} + "（" + extraMessage + "）")
		{
		}
	}
}
