using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch20.Models.Entities
{
    public class Prod
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public Colors Color { get; set; }
        public bool InStock { get; set; }
        public long SupplierId { get; set; }
        public Sup Supplier { get; set; }

    }
}
