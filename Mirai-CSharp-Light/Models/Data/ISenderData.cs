using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
    /// <summary>
    /// 消息发送者信息
    /// </summary>
    public interface ISenderData
    {
        /// <summary>
        /// QQ号
        /// </summary>
        public long Id { get; }
    }
}
