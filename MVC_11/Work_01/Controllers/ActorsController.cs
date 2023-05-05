using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_01.Models;
using Work_01.Models.MetaData;
using Work_01.ViewModel;

namespace Work_01.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MovieDbContext db = new MovieDbContext();
        // GET: Actors
        public ActionResult Index()
        {
            return View(db.Actors.ToList());
        }
        public ActionResult ActorsByMovie(int id)
        {
            ViewBag.Movie = db.Movies.First(x => x.MovieId == id).Title;
            return View(db.Actors.Where(x => x.MovieId == id).ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Movies = db.Movies.Select(x => new { x.MovieId, x.Title }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ActorViewModel a)
        {
            if (ModelState.IsValid)
            {
                Actors ac = new Actors
                {
                    Name = a.Name,
                    Gender = (int)a.Gender,
                    MovieId = a.MovieId,
                    Picture = "download.png"
                };
                if(a.Picture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(a.Picture.FileName);
                    a.Picture.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                    ac.Picture = fileName;
                }
                db.Actors.Add(ac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(a);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Movies = db.Movies.Select(x => new { x.MovieId, x.Title }).ToList();
            var ac = db.Actors.First(x => x.ActorId == id);
            ViewBag.Pic = ac.Picture;
            return View(new ActorViewModel
            {
                ActorId = ac.ActorId,
                Name = ac.Name,
                Gender = (Gender)ac.Gender,
                MovieId = ac.MovieId
            });
        }

        [HttpPost]
        public ActionResult Edit(ActorViewModel a)
        {
            var ac = db.Actors.First(x => x.ActorId == a.ActorId);
            if (ModelState.IsValid)
            {
                ac.Name = a.Name;
                ac.Gender = (int)a.Gender;
                ac.MovieId = a.MovieId;
                if(a.Picture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(a.Picture.FileName);
                    a.Picture.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                    ac.Picture = fileName;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Movies = db.Movies.Select(x => new { x.MovieId, x.Title }).ToList();
            ViewBag.Pic = ac.Picture;
            return View(a);
        }
        public ActionResult Delete(int id)
        {
            ViewBag.Movies = db.Movies.Select(x => new { x.MovieId, x.Title }).ToList();
            var ac = db.Actors.First(x => x.ActorId == id);
            ViewBag.Pic = ac.Picture;
            return View(new ActorViewModel
            {
                ActorId = ac.ActorId,
                Name = ac.Name,
                Gender = (Gender)ac.Gender,
                MovieId = ac.MovieId
            });
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {           
            var ac = new Actors { ActorId = id };            
            db.Entry(ac).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}