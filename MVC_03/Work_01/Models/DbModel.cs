using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work_01.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required, StringLength(40)]
        public string Name { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
    }

    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}