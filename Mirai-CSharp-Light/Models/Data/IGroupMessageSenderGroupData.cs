using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
    /// <summary>
    /// 群消息发送者在群里的信息
    /// </summary>
    public interface IGroupMessageSenderGroupData
    {
        /// <summary>
        /// 群号
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// 群名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Bot在群里的权限
        /// </summary>
        public GroupPermission Permission { get; }
    }
}
