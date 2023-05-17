namespace Work_01.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Work_01.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Work_01.Models.EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Work_01.Models.EmployeeDbContext context)
        {
            context.Employees.Add(new Employee { EmployeeName = "Mr. Burns", JoinDate = new DateTime(2016, 09, 20) });
            context.Employees.Add(new Employee { EmployeeName = "Alexender Mikhaev", JoinDate = DateTime.Parse("2019,02,01") });
            context.SaveChanges();
        }
    }
}
