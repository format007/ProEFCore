using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ch20.Models.Entities
{
    public enum Colors
    {
        Red, Green, Blue
    }

    public class Product
    {
        private double databasePrice;
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { 
            get => databasePrice * 2;
            set => databasePrice = value; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool SoftDeleted { get; set; }
        public byte[] RowVersion { get; set; }
        //[Required]
        public int ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }

        public Colors Color { get; set; }
        public Supplier Supplier { get; set; }
    }
}
