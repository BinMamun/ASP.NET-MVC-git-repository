using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work_01.Models
{
    public enum Genre {Adventure=1, Classic, Thriller, Biography}
    public class Book
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [EnumDataType(typeof(Genre)), Range(1, int.MaxValue, ErrorMessage = "Select a Genre")]
        public Genre Genre { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Cover Price (Tk)"), DisplayFormat(DataFormatString ="{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal CoverPrice { get; set; }
    }

    public class BookDbContext : DbContext
    { 
        public BookDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Book> Books { get; set; }
    }
    
    public class DbInitializer: DropCreateDatabaseIfModelChanges<BookDbContext>
    {
        protected override void Seed(BookDbContext context)
        {
            context.Books.AddRange(new Book[]
            {
                new Book{Title="B1", Genre= Genre.Adventure, CoverPrice = 29.99M},
                new Book{Title="B2", Genre= Genre.Classic, CoverPrice = 30.00M},
                new Book{Title="B3", Genre= Genre.Thriller, CoverPrice = 15.25M},
                new Book{Title="B4", Genre= Genre.Biography, CoverPrice = 50.00M}
            });
            context.SaveChanges();
        }
    }
}