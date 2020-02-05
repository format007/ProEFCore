using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch20.Models.Entities
{
    public class Supplier
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
