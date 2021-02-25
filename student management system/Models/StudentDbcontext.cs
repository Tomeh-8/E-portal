using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_system.Models
{
    public class StudentDbcontext:IdentityDbContext<ApplicationUser>
    {
        public StudentDbcontext(DbContextOptions<StudentDbcontext> options) : base(options)
        {

        }
     
        public DbSet<Course> studentCourse { get; set; }

        public DbSet<Student> studentInfo { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

  
}
