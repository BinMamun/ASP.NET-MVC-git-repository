using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_16.Models
{
    public class Brand
    {
        public Brand() { Products = new List<Product>(); } //constructor
        public int BrandId { get; set; }
        [Required, StringLength(40), Display(Name ="Brand Name")]
        public string BrandName { get; set; }
        [Required, StringLength(30), Display(Name = "Origin")]
        public string Origin { get; set; }
        //Navigation
        public virtual ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        [Required, StringLength(40), Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required, Column(TypeName = "Date"), Display(Name = "Release Date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required, Column(TypeName = "Money"), DisplayFormat(DataFormatString = "{0: 0.00}")]
        public decimal Price { get; set; }
        [Required, StringLength(150)]
        public string Picture { get; set; }
        public bool Discontinued { get; set; }

        //Foreign Key
        [Required, ForeignKey("Brand"), Display(Name ="Brand")]
        public int BrandId { get; set; }
        //Navigation
        public Brand Brand{ get; set; }
    }

    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
        {
            Database.SetInitializer(new Seeder());
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products{ get; set; }
    }

    public class Seeder : DropCreateDatabaseIfModelChanges<StoreDbContext>
    {
        protected override void Seed(StoreDbContext context)
        {
            Brand b = new Brand { BrandName = "Hamko", Origin = "China" };
            b.Products.Add(new Product { ProductName = "12V 25Amp Battery", ReleaseDate = new DateTime(2022, 05, 10), Price = 9450.00M, Discontinued = false, Picture = "images.png" });
            context.Brands.Add(b);
            context.SaveChanges();
        }
    }
}