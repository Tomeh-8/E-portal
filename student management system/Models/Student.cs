using System;
using System.Collections.Generic;
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
    }
}
