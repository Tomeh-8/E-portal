using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_system.Models
{
    public class Register
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "passwords do not match")]
        public string ConfirmPassword { get; set; }
}
}
