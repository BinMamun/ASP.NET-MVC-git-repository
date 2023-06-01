using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Work_01.ViewModel
{
    public class ProductionVM
    {
        public int Id { get; set; }
       
        public string Item { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime From { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime To { get; set; }
        public int PerDay { get; set; }
        [Display(Name ="Total Production")]
        public int TotalProduction { get; set; }
    }
}