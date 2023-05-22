using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_01.Models;

namespace Work_01.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryDbContext db = new LibraryDbContext();
        // GET: Books
        public ActionResult Index()
        {
            ViewBag.Count = db.Books.Count();
            return View(db.Books.ToList());
        }

        public ActionResult BooksByGenre(int id)
        {
            ViewBag.GenreName = db.Genres.First(x => x.GenreId == id).GenreName;
            ViewBag.Count = db.Genres.First(x => x.GenreId == id).Books.Count();
            return View(db.Books.Where(x => x.GenreId == id).ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Genres = db.Genres.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Genres = db.Genres.ToList();
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Genres = db.Genres.ToList();
            return View(db.Books.First(x => x.BookId == id));
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Genres = db.Genres.ToList();
            return View(book);
        }

        public ActionResult Delete(int id)
        {
            ViewBag.Genres = db.Genres.ToList();
            return View(db.Books.First(x => x.BookId == id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Book book)
        {
            ViewBag.Genres = db.Genres.ToList();
            db.Entry(book).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}