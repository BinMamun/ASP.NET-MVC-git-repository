using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_01.Models;

namespace Work_01.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ArticleDbContext db = new ArticleDbContext();
        // GET: Articles
        public ActionResult Index()
        {
            ViewBag.Count = db.Articles.Count();
            return View(db.Articles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        public ActionResult Edit(int id)
        {            
            return View(db.Articles.First(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }
        public ActionResult Delete(int id)
        {
            var ar = db.Articles.First(x => x.Id == id);
            db.Entry(ar).State = EntityState.Deleted;
            //db.Articles.Remove(ar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}