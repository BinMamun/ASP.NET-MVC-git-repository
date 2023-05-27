using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_01.Models;
using Work_01.ViewModel;

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
        public ActionResult Create(EmployeeViewModel emv)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee
                {
                    Name = emv.Name,
                    JoinDate = emv.JoinDate,
                    Address = emv.Address,
                    Picture = "download.png"
                };
                if(emv.Picture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(emv.Picture.FileName);
                    emv.Picture.SaveAs(Server.MapPath("~/Uploads/")+fileName);
                    emp.Picture = fileName;
                }
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emv);
        }

        public ActionResult Edit(int id)
        {
            var emp = db.Employees.First(x => x.EmployeeId == id);
            ViewBag.Pic = emp.Picture;
            return View(new EmployeeViewModel {
                EmployeeId = emp.EmployeeId,
                Name = emp.Name,
                JoinDate = emp.JoinDate,
                Address = emp.Address
            });
        }
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel emv)
        {
            var empEdit = db.Employees.First(x => x.EmployeeId == emv.EmployeeId);
            if (ModelState.IsValid)
            {
                empEdit.Name = emv.Name;
                empEdit.JoinDate = emv.JoinDate;
                empEdit.Address = emv.Address;
                if(emv.Picture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(emv.Picture.FileName);
                    emv.Picture.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                    empEdit.Picture = fileName;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            };
            ViewBag.Pic = empEdit.Picture;
            return View(emv);
        }
        public ActionResult Delete(int id)
        {
            var emp = db.Employees.First(x => x.EmployeeId == id);
            ViewBag.Pic = emp.Picture;
            return View(new EmployeeViewModel
            {
                EmployeeId = emp.EmployeeId,
                Name = emp.Name,
                JoinDate = emp.JoinDate,
                Address = emp.Address
            });
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(Employee emp)
        {            
            ViewBag.Pic = emp.Picture;            
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}