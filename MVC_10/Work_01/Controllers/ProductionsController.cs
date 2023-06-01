using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work_01.Models;
using Work_01.ViewModel;

namespace Work_01.Controllers
{
    public class ProductionsController : Controller
    {
        private readonly ProductionDbContext db = new ProductionDbContext();
        // GET: Productions
        public ActionResult Index(int pg=1)
        {
            ViewBag.TotalPages = (int)Math.Ceiling((double)db.Productions.Count() / 5);
            ViewBag.CurrentPage = pg;
            ViewBag.TotalProduction = db.Productions.Count();
            return View(db.Productions.OrderBy(x => x.Id).Skip((pg - 1) * 5).Take(5).ToList());
        }

        public ActionResult IndexV2(int pg = 1)
        {
            var data = db.Productions.OrderBy(x => x.Id).ToPagedList(pg, 5);
            return View(data);
        }

        public ActionResult IndexV3(int pg = 1)
        {
            var data = db.Productions
                .OrderBy(x => x.Id)
                .ToList()
                .Select(x => new ProductionVM
                {
                    Id = x.Id,
                    Item = x.Item,
                    From = x.From,
                    To = x.To,
                    PerDay = x.PerDay,
                    TotalProduction = ((x.To - x.From).Days + 1) * x.PerDay
                })                
                .ToPagedList(pg, 5);

            return View(data);
        }
    }
}