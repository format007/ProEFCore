using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch20.Models.Entities
{
    public class TempClass
    {
        public TempClass(string config)
        {
            Config = config;
        }

        public string Config { get; }
    }
}
