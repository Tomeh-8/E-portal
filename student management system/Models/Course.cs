using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_system.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string CourseTitle { get; set; }

        public int CourseCode { get; set; }

        public bool CourseStatus { get; set; }
    }
}
