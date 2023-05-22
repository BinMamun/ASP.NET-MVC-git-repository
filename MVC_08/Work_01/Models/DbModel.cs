using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work_01.Models
{
    public class Genre
    {
       public Genre()
        {
            Books = new List<Book>();
        } 
        public int GenreId { get; set; }
        [Required, StringLength(30), Display(Name="Genre Name")]
        public string GenreName{ get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    public class Book
    {
        public int BookId { get; set; }
        [Required, StringLength(40)]
        public string Title { get; set; }
        [Required,Column(TypeName ="money"), 
            DisplayFormat(DataFormatString ="{0: 0.00}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
        [ForeignKey("Genre"), Display(Name = "Genre")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }

    public class LibraryDbContext: DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}