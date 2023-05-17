using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work_01.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required, StringLength(40), Display(Name ="Employee Name")]
        public string EmployeeName { get; set; }
        [Required, Display(Name="Join Date"), DisplayFormat(DataFormatString ="{0: dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime JoinDate { get; set; }
        [StringLength(20)]
        public string Contact { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}