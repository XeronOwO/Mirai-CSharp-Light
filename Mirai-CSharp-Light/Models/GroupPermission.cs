﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models
{
    /// <summary>
    /// 群聊权限/身份
    /// </summary>
    public enum GroupPermission
    {
        /// <summary>
        /// 成员
        /// </summary>
        Member,
        /// <summary>
        /// 管理员
        /// </summary>
        Administrator,
        /// <summary>
        /// 群主
        /// </summary>
        Owner,
    }
}
