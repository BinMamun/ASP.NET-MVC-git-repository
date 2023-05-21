using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work_01.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage ="Please enter a book name"), StringLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Select a genre"), StringLength(50)]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Please enter price"), Column(TypeName = "money")]
        public decimal Price{ get; set; }
    }
    public class BookDbContext: DbContext
    {
        public BookDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Book> Books { get; set; }
    }

    public class DbInitializer : DropCreateDatabaseIfModelChanges<BookDbContext>
    {
        protected override void Seed(BookDbContext context)
        {
            Book[] books = new Book[]
            {
                new Book{Title="MVC-05", Genre="Programming", Price=295.5M},
                new Book{Title="C#", Genre="Programming", Price=200M},
                new Book{Title="Angular", Genre="Programming", Price=305.05M}
            };
            context.Books.AddRange(books);
        }
    }
}