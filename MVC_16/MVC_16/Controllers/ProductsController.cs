using MVC_16.Models;
using MVC_16.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return View(db.Products.Include(x=> x.Brand).ToList());
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
                ViewBag.Brand = db.Brands.Select(x => new { x.BrandId, x.BrandName }).ToList();
                db.Products.Add(pd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public ActionResult Edit(int id)
        {
            Product p = db.Products.First(x => x.ProductId == id);  
            ViewBag.Brand = db.Brands.Select(x => new { x.BrandId, x.BrandName }).ToList();
            ViewBag.Pic = p.Picture;
            return View(new ProductViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ReleaseDate = p.ReleaseDate,
                Price = p.Price,
                Discontinued = p.Discontinued,
                BrandId = p.BrandId
                
            });           
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel p)
        {
            Product pd = db.Products.First(x => x.ProductId == p.ProductId);
            if (ModelState.IsValid)
            {
                pd.ProductName = p.ProductName;
                pd.BrandId = p.BrandId;
                pd.ReleaseDate = p.ReleaseDate;
                pd.Discontinued = p.Discontinued;
                pd.Price = p.Price; 

                if (p.Picture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(p.Picture.FileName);
                    p.Picture.SaveAs(Server.MapPath("~/Images/") + fileName);
                    pd.Picture = fileName;
                }
                ViewBag.Brand = db.Brands.ToList();
                ViewBag.Pic = pd.Picture;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public ActionResult Delete(int id)
        {
            return View(db.Products.Include(x => x.Brand).First(x => x.ProductId == id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DoDelete(int id)
        {
            var p = new Product { ProductId = id };            
            db.Entry(p).State = EntityState.Deleted;
	        db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}