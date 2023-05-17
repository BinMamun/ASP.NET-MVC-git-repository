using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_01.Models;

namespace Work_01.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext db = new EmployeeDbContext();
        // GET: Employees
        public ActionResult Index()
        {
            ViewBag.Count = db.Employees.Count();
            return View(db.Employees.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }
        public ActionResult Edit(int id)
        {
            return View(db.Employees.First(x => x.EmployeeId == id));
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }

        public ActionResult Delete(int id)
        {
            return View(db.Employees.First(x => x.EmployeeId == id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DoDelete(int id)
        {
            var emp = new Employee { EmployeeId = id };
            db.Entry(emp).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
