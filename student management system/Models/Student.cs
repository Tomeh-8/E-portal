using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_system.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StateOfOrigin { get; set; }

        public string Nationality { get; set; }

        public int Age { get; set; }

        public int PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Department { get; set; }

        public int Level { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
