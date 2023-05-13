using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_01.Models;

namespace Work_01.Controllers
{
    public class HomeController : Controller
    {

        private readonly BookDbContext db = new BookDbContext();
        public ActionResult Index()
        {
            ViewBag.Count = db.Books.Count();
            return View(db.Books.ToList());
        }
    }
}