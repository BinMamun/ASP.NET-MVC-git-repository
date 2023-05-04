using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_01.Models;

namespace Work_01.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext db = new MovieDbContext();
        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movies m)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Edit(int id)
        {
            return View(db.Movies.First(x => x.MovieId == id));
        }
        [HttpPost]
        public ActionResult Edit(Movies m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Delete(int id)
        {
            return View(db.Movies.First(x => x.MovieId == id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Movies m = db.Movies.First(x => x.MovieId == id);
            db.Entry(m).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}