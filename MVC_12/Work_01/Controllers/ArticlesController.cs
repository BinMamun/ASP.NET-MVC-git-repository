using System;
using System.Collections.Generic;
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
            return View();
        }
        public PartialViewResult ArticleList(int pg=1)
        {
            ViewBag.CurrentPage = pg;
            ViewBag.TotalPages = (int)Math.Ceiling((db.Articles.Count() / 5.0));
            return PartialView("_ArticleTable", db.Articles.OrderBy(x=> x.Id).Skip((pg-1)*5).Take(5).ToList());
        }
    }
}