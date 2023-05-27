using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work_01.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required, StringLength(30)]
        public string Name{ get; set; }
        [Required, Column(TypeName ="Date"), Display(Name ="Join Date"),
            DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate{ get; set; }
        [Required, StringLength(100)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Picture { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Employee> Employees { get; set; }
    }

    public class DbInitializer: DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            context.Employees.Add(new Employee { Name = "Ariful Islam", JoinDate = new DateTime(2021, 11, 15), Address = "Sirajgonj,Bangladesh", Picture = "download.png" });
            context.SaveChanges();
        }
    }
}