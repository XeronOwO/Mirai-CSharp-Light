using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
    internal class GroupMessageSenderData : IGroupMessageSenderData
    {
        public long Id { get; set; }

        public string MemberName { get; set; } = "";

        public string SpecialTitle { get; set; } = "";

        public GroupPermission Permission { get; set; }

        public long JoinTimestamp { get; set; }

        public DateTime JoinDateTime { get; set; }

        public long LastSpeakTimestamp { get; set; }

        public DateTime LastSpeakDateTime { get; set; }

        public int MuteTimeRemaining { get; set; }

        public GroupMessageSenderGroupData Group_ = new();

        public IGroupMessageSenderGroupData Group => Group_;
    }
}
