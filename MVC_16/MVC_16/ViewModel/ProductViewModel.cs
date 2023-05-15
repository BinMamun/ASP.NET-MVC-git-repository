using MVC_16.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_16.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required, StringLength(40), Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required, Display(Name = "Release Date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required,DisplayFormat(DataFormatString = "{0: 0.00}")]
        public decimal Price { get; set; }
        public HttpPostedFileBase Picture { get; set; }
        public bool Discontinued { get; set; }
        //Foreign Key
        public int BrandId { get; set; }
        //Navigation
        public Brand Brand { get; set; }
    }
}
