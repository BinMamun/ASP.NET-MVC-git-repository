using MVC_16.Models;
using MVC_16.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_16.Controllers
{
    public class ProductsController : Controller
    {
        readonly StoreDbContext db = new StoreDbContext();   
        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult Create() 
        {
            ViewBag.Brand = db.Brands.Select(x => new {x.BrandId, x.BrandName}).ToList();
            return View(); 
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel p)
        {
            if(ModelState.IsValid)
            {
                Product pd = new Product
                {
                    ProductName = p.ProductName,
                    BrandId = p.BrandId,
                    ReleaseDate = p.ReleaseDate,
                    Discontinued = p.Discontinued,
                    Price = p.Price,
                    Picture = "images.png"
                };

                if(p.Picture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(p.Picture.FileName);
                    p.Picture.SaveAs(Server.MapPath("~/Images/") + fileName);
                    pd.Picture = fileName;
                }
                db.Products.Add(pd);
                db.SaveChanges();
            }
            return View(p);
        }
    }
}