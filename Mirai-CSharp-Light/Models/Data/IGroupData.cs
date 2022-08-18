using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
    /// <summary>
    /// 用户在群里的信息
    /// </summary>
    public interface IGroupData
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
        /// Bot在群里的权限/身份
        /// </summary>
        public GroupPermission Permission { get; }
    }
}
