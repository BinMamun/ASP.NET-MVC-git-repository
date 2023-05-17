using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work_02.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required, StringLength(20), Display(Name = "Student Name")]
        public string Name { get; set; }
        [Required, Display(Name = "Date of birth"),
            DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}",
            ApplyFormatInEditMode =true)]
        public DateTime Dob { get; set; }
        [Required, StringLength(100)]
        public string Address { get; set; }

    }

    public class StudentDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}