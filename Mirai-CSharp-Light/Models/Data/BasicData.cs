using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
    internal class BasicData : IBasicData
    {
        public long Id { get; set; }

        public string NickName { get; set; } = "";

        public string Remark { get; set; } = "";
    }
}
