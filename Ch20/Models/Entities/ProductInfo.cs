using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ch20.Models.Entities
{
    public class ProductInfo
    {
        public int Id { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Heigth { get; set; }
        [Required]
        public int Depth { get; set; }
    }
}
