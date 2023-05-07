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
        private readonly MVC_02DbContext db = new MVC_02DbContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Count = db.Customers.Count();
            ViewData["FirstCustomer"] = db.Customers.First().CompanyName;
            return View(db.Customers.OrderBy(c=> c.CustomerID).ToList());
        }
    }
}