﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
    internal class IdData : IIdData
    {
        public long id;

        [JsonIgnore]
        public long Id => id;
    }
}
