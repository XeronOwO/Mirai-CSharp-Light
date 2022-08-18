using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
    /// <summary>
    /// 基本用户信息接口
    /// </summary>
    public interface IUserData : ISenderData
    {
        /// <summary>
        /// QQ昵称
        /// </summary>
        public string Nickname { get; }

        /// <summary>
        /// 评论
        /// </summary>
        public string Remark { get; }
    }
}
