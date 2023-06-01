using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work_01.Models
{
    public class Production
    {
        public int Id { get; set; }
        [Required, StringLength(40)]
        public string Item { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime From { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime To { get; set; }
        public int PerDay { get; set; }
    }

    public class ProductionDbContext : DbContext
    {
        public ProductionDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Production> Productions { get; set; }
    }
    public class DbInitializer: DropCreateDatabaseIfModelChanges<ProductionDbContext>
    {
        protected override void Seed(ProductionDbContext context)
        {
            string[] items = new string[] { "Coil", "Pipe", "Sheet", "Iron", "Tool", "Box" };
            DateTime dt = new DateTime(2023, 1, 1);
            for(int i =0; i < items.Length; i++)
            {
                context.Productions.Add(new Production { Item = items[i], From = dt.AddDays(i + i * 4), To = dt.AddDays(i + i * 4).AddDays(4), PerDay=270 });
            }

            dt = new DateTime(2023, 1, 1);
            for (int i = 0; i < items.Length; i++)
            {
                context.Productions.Add(new Production { Item = items[i], From = dt.AddDays(i + i * 4), To = dt.AddDays(i + i * 4).AddDays(4), PerDay = 250 });
            }
            dt = new DateTime(2023, 1, 1);
            for (int i = 0; i < items.Length; i++)
            {
                context.Productions.Add(new Production { Item = items[i], From = dt.AddDays(i + i * 4), To = dt.AddDays(i + i * 4).AddDays(4), PerDay = 280 });
            }
            dt = new DateTime(2023, 1, 1);
            for (int i = 0; i < items.Length; i++)
            {
                context.Productions.Add(new Production { Item = items[i], From = dt.AddDays(i + i * 4), To = dt.AddDays(i + i * 4).AddDays(4), PerDay = 270 });
            }
            context.SaveChanges();
        }
    }
}