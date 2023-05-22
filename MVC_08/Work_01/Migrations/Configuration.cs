namespace Work_01.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Work_01.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Work_01.Models.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Work_01.Models.LibraryDbContext context)
        {
            Genre g1 = new Genre { GenreName = "Novel", Description = "Life and time goes on" };
            g1.Books.Add(new Book { Title = "A day in war", Price = 599.99M, });
            context.Genres.Add(g1);
            context.SaveChanges();
        }
    }
}
