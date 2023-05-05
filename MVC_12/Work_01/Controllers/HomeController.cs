using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Work_01.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Score()
        {
            Thread.Sleep(2000);
            return PartialView();
        }

        public JsonResult CurrentScore()
        {
            Thread.Sleep(2000);
            return Json(new { over = 17.5, score="178/3" });
        }
    }
}