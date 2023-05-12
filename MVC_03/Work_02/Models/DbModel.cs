using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work_02.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; }
        
        [Required, StringLength(40)]
        public string Author { get; set; }

        [Required, Column(TypeName="Money")]
        public decimal CoverPrice { get; set; }
    }

    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}