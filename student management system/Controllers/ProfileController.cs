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
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var biodata = _db.studentInfo.Where(a => a.StudentId == UserId);
            return View(biodata);
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


       public IActionResult StudentCourse()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // var displayContent = _db.studentCourse.Where(a => a.CourseId == model.CourseId);
            var courses = _db.studentCourse.Where(x => x.RefId == UserId).ToList();
            return View(courses);
        }

        public IActionResult CourseCreate()
        {
        
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> CourseCreate(student_management_system.Models.StudentCourse model)
        {
            model.RefId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _db.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("StudentCourse");
            }
            
            return View(model);
        }

    }
}
       