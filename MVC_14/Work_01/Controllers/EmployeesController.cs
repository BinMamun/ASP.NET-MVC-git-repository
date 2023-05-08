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
        public ActionResult Index()
        {
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
                return PartialView("_SuccessPartial");
            }
            return PartialView("_FailPartial");
        }

        public ActionResult Edit(int id)
        {
            return View(db.Employees.First(x=> x.Id == id));
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
    }
}