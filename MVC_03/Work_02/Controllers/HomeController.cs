using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_02.Models;

namespace Work_02.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookDbContext db = new BookDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b);
        }
    }
}