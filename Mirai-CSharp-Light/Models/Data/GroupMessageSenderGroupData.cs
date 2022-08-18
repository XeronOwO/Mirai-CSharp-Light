using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
    internal class GroupMessageSenderGroupData : IGroupMessageSenderGroupData
    {
        public long Id { get; set; }

        public string Name { get; set; } = "";

        public GroupPermission Permission { get; set; }
    }
}
