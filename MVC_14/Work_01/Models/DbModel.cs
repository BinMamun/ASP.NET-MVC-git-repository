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
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, Column(TypeName ="date"), Display(Name ="Join Date"), DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime JoinDate { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }

    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext()
        {
            Database.SetInitializer(new Seeder());
        }
        public DbSet<Employee> Employees { get; set; }
    }

    public class Seeder: DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            context.Employees.Add(new Employee { Name = "E1", Salary = 451000M, JoinDate = DateTime.Now});
            context.Employees.Add(new Employee { Name = "E2", Salary = 652100M, JoinDate = DateTime.Now});
            context.SaveChanges();
        }
    }
}