using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_02.Models;

namespace Work_02.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentDbContext db = new StudentDbContext();
        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }

        public ActionResult Edit(int id)
        {
            return View(db.Students.First(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Entry(s).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }

        public ActionResult Delete(int id)
        {
            return View(db.Students.First(x => x.Id == id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DoDelete(int id)
        {
            var s = new Student { Id = id};
            db.Entry(s).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}