﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 上传类别的拓展功能类
	/// </summary>
	public static class UploadTypeExternsions
	{
		/// <summary>
		/// 上传内容的类别转成字符串
		/// </summary>
		/// <param name="type">上传内容的类别</param>
		/// <returns>转换的字符串</returns>
		/// <exception cref="System.Exception"></exception>
		public static string GetString(this UploadType type)
		{
			return type switch
			{
				UploadType.Friend => "friend",
				UploadType.Group => "group",
				UploadType.Temp => "temp",
				_ => throw new System.Exception("未知的上传内容的类别"),
			};
		}
	}

	/// <summary>
	/// 上传内容的类别
	/// </summary>
	public enum UploadType
	{
		/// <summary>
		/// 好友
		/// </summary>
		Friend,
		/// <summary>
		/// 群聊
		/// </summary>
		Group,
		/// <summary>
		/// 临时
		/// </summary>
		Temp,
	}
}
