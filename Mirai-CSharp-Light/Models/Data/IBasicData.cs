using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
    /// <summary>
    /// Bot信息接口
    /// </summary>
    public interface IBasicData
    {
        /// <summary>
        /// QQ号
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// QQ昵称
        /// </summary>
        public string NickName { get; }

        /// <summary>
        /// 评论
        /// </summary>
        public string Remark { get; }
    }
}
