using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work_01.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required, StringLength(40)]
        public string Title { get; set; }
        [Required, Column(TypeName ="date"), Display(Name ="Release Date"), DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime ReleaseDate { get; set; }
        [Required, Display(Name ="User Rating")]
        public double UserRating { get; set; }
        [Required, Display(Name ="Total View")]
        public int TotalView { get; set; }
    }

    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Article> Articles { get; set; }
    }

    public class DbInitializer : DropCreateDatabaseIfModelChanges<ArticleDbContext>
    {
        protected override void Seed(ArticleDbContext context)
        {
            context.Articles.Add(new Article { Title = "Rise of Taliban", ReleaseDate = new DateTime(2016, 08, 21), UserRating = 4.5, TotalView = 1547800 });
            context.Articles.Add(new Article { Title = "The world's shop", ReleaseDate = new DateTime(2018, 03, 07), UserRating = 4.7, TotalView = 185900 });
            context.Articles.Add(new Article { Title = "Covid-19", ReleaseDate = new DateTime(2020, 02, 20), UserRating = 4.2, TotalView = 252000 });
            context.SaveChanges();
        }
    }
}