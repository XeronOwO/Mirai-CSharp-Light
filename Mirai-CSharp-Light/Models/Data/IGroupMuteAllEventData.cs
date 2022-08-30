﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 某个群名改变事件信息
	/// </summary>
	public interface IGroupMuteAllEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 原本是否处于全员禁言
		/// </summary>
		public bool Origin { get; }

		/// <summary>
		/// 现在是否处于全员禁言
		/// </summary>
		public bool Current { get; }

		/// <summary>
		/// 全员禁言的群信息
		/// </summary>
		public IGroupData Group { get; }

		/// <summary>
		/// 操作的管理员或群主信息，当null时为Bot操作
		/// </summary>
		public IGroupMemberData? Operator { get; }
	}
}
