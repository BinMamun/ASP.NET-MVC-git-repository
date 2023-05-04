﻿using PagedList;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Work_01.Models;
using Work_01.ViewModels;

namespace Work_01.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MovieDbContext db = new MovieDbContext();
        // GET: Actors
        public ActionResult Index(int pg = 1)
        {
            ViewBag.Count = db.Movies.Count();
            return View(db.Actors.ToList().OrderBy(x => x.ActorId).ToPagedList(pg, 5));
        }

        public ActionResult Create()
        {
            ViewBag.Movies = db.Movies.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ActorViewModel a)
        {
            if (ModelState.IsValid)
            {
                Actors ac = new Actors { Name = a.Name, Gender = (int)a.Gender, MovieId = a.MovieId, Picture = "download.png" };
                if (a.Picture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(a.Picture.FileName);
                    a.Picture.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                    ac.Picture = fileName;
                }
                db.Actors.Add(ac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Movies = db.Movies.ToList();
            return View(a);
        }
        //public ActionResult Edit(int id)
        //{
        //    Actors a = db.Actors.First(x => x.ActorId == id);
        //    ViewBag.Movies = db.Movies.ToList();
        //    ViewBag.Picture = a.Picture;
        //    return View(new ActorViewModel
        //    {
        //        ActorId = a.ActorId,
        //        Name = a.Name,
        //        Gender = a.Gender,
        //        MovieId = a.MovieId
        //    }) ;
        //}

        //[HttpPost]
        //public ActionResult Edit(ActorViewModel act)
        //{            
        //    if (ModelState.IsValid)
        //    {
        //        var ac = db.Actors.First(x => x.ActorId == act.ActorId);
        //        ac.ActorId = act.ActorId;
        //        ac.Name = act.Name;
        //        ac.Gender = (int)act.Gender;
        //        ac.MovieId = act.MovieId;

        //        if (act.Picture != null)
        //        {
        //            string fileName = Guid.NewGuid() + Path.GetExtension(act.Picture.FileName);
        //            act.Picture.SaveAs(Server.MapPath("~/Uploads/") + fileName);
        //            ac.Picture = fileName;
        //        }                
        //        db.Entry(ac).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Movies = db.Movies.ToList();
        //    ViewBag.Picture = act.Picture;
        //    return View(act);
        //}

        //public ActionResult Delete(int id)
        //{
        //    Actors ac = db.Actors.First(x => x.ActorId == id);
        //    ViewBag.Picture = ac.Picture;
        //    return View(new ActorViewModel
        //    {
        //        ActorId = ac.ActorId,
        //        Name = ac.Name,
        //        Gender = ac.Gender,
        //        MovieId = ac.MovieId
        //    });
        //}
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    Actors ac = db.Actors.First(x => x.ActorId == id);
        //    ViewBag.Picture = ac.Picture;
        //    db.Entry(ac).State = EntityState.Deleted;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}