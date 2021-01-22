using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_system.Models
{
    public class StudentDbcontext:IdentityDbContext
    {
        public StudentDbcontext(DbContextOptions<StudentDbcontext> options) : base(options)
        {

        }
        public DbSet<Login> students { get; set; }
    }

  
}
