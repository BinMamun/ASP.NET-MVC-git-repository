using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_01.Models;

namespace Work_01.Controllers
{
    public class GenresController : Controller
    {
        private readonly LibraryDbContext db = new LibraryDbContext();
        public ActionResult Index()
        {
            ViewBag.Count = db.Genres.Count();
            return View(db.Genres.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        public ActionResult Edit(int id)
        {
            return View(db.Genres.First(x => x.GenreId == id));
        }
        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }
        public ActionResult Delete(int id)
        {
            return View(db.Genres.First(x => x.GenreId == id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(Genre genre)
        {
            db.Entry(genre).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}