﻿using Mirai.CSharp.Light.Models.Data;
using Mirai.CSharp.Light.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.EventArgs
{
    /// <summary>
    /// 消息事件参数接口
    /// </summary>
    public interface IMessageEventArgs
	{
		/// <summary>
		/// 消息类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 消息链
		/// </summary>
		public IChatMessage[] MessageChain { get; }
	}
}
