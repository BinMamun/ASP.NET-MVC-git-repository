using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Work_01.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [Required, StringLength(30)]
        public string Name { get; set; }
        [Required, Display(Name = "Join Date"),
            DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }
        [Required, StringLength(100)]
        public string Address { get; set; }
        public HttpPostedFileBase Picture { get; set; }
    }
}