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
        private readonly BookDbContext db = new BookDbContext();
        // GET: Books
        public ActionResult Index()
        {
            ViewBag.Count = db.Books.Count();
            return View(db.Books.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.GenreOptions = new string[] { "Programming", "Web Authoring", "Frontend Development", "Backend Development" };
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreOptions = new string[] { "Programming", "Web Authoring", "Frontend Development", "Backend Development" };

            return View();
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            return View(db.Books.First(x => x.BookId == id));
        }
        public ActionResult Edit(int id)
        {
            ViewBag.GenreOptions = new string[] { "Programming", "Web Authoring", "Frontend Development", "Backend Development" };
            return View(db.Books.First(x=> x.BookId == id));
        }
        [HttpPost]
        public ActionResult Edit(Book b)
        {
            if (ModelState.IsValid)
            {
                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreOptions = new string[] { "Programming", "Web Authoring", "Frontend Development", "Backend Development" };

            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(db.Books.First(x => x.BookId == id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DoDelete(Book book)
        {
            db.Entry(book).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}