using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using student_management_system.Models;

namespace student_management_system.Controllers
{
    public class ProfileController : Controller
    {
        private readonly StudentDbcontext _db;

        public ProfileController(StudentDbcontext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BioData()
        {
            var display = _db.studentInfo.ToList();
            return View(display);
        }

        public IActionResult CreateBioData()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBioData(student_management_system.Models.Student model)
        {
           
            model.StudentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _db.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Biodata");
            }

            return View(model);
        }


        public IActionResult Course()
        {
            var displayContent = _db.studentCourse.ToList();
            return View(displayContent);
        }


        [HttpPost]
        public async Task<IActionResult> CourseCreate(student_management_system.Models.Course model)
        {
            if (ModelState.IsValid)
            {
                _db.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Course");
            }
            
            return View(model);
        }

    }
}
