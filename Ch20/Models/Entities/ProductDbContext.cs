using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Ch20.Models.Entities
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Prod> Prods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.SoftDeleted != true);
            modelBuilder.Entity<Product>(cfg =>
            {
                cfg.Property(p => p.Price)
                    .HasColumnType("decimal(8,2)")
                    .HasField("databasePrice").UsePropertyAccessMode(PropertyAccessMode.Field);

                cfg.Property(p => p.Name).HasMaxLength(100);

                cfg.Property<DateTime>("Created").HasDefaultValueSql("getdate()");

                cfg.Property(p => p.RowVersion).IsRowVersion();
            });
        }
    }
}