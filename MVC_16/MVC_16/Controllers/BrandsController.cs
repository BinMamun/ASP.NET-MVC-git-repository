using MVC_16.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_16.Controllers
{
    public class BrandsController : Controller
    {
        private readonly StoreDbContext db = new StoreDbContext();
        // GET: Brands
        public ActionResult Index()
        {
            return View(db.Brands.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand b)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(b);
                db.SaveChanges();
                return PartialView("_SuccessPartial", true);
            }
            return PartialView("_SuccessPartial", false);
        }

        public ActionResult Edit(int id)
        {
            return View(db.Brands.First(x=> x.BrandId == id));
        }
        [HttpPost]
        public ActionResult Edit(Brand b)
        {
            if (ModelState.IsValid)
            {
                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b);
        }
        public ActionResult Delete(int id)
        {
            return View(db.Brands.First(x => x.BrandId == id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Brand b = db.Brands.First(x => x.BrandId == id);
            db.Entry(b).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");           
        }
    }
}