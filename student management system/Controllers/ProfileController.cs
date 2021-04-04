using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using student_management_system.Models;
using student_management_system.data.Interface;

namespace student_management_system.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IBioDataRepository _biodataRepository;
        private readonly ICourseRepository _courseRepository;

        public ProfileController(IBioDataRepository biodataRepository, ICourseRepository courseRepository)
        {
            _biodataRepository = biodataRepository;
            _courseRepository = courseRepository;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BioData()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var biodata = _biodataRepository.GetAllStudentsInfo().Where(b => b.StudentId == UserId);
            return View(biodata);
        }

        [HttpGet]
        public IActionResult CreateBioData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBioData(Student model)
        {

            model.StudentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _biodataRepository.AddStudentInfo(model);
                return RedirectToAction("Biodata");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditBioData(string id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            var showBioData = _biodataRepository.GetStudentInfo(id);
            return View(showBioData);
        }

        [HttpPost]
        public IActionResult EditBioData(Student student)
        {
            if (ModelState.IsValid)
            {
                Student studentInfo =  _biodataRepository.EditStudentInfo(student);
                return RedirectToAction("Biodata");
            }
            
            return View(student);
        }
        
        
        
       public IActionResult StudentCourse()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var courses = _courseRepository.ShowCourses().Where(x => x.RefId == UserId).ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult CreateCourse()
        {
        
            return View();
        }


        [HttpPost]
        public IActionResult CreateCourse(StudentCourse course)
        {
            course.RefId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _courseRepository.AddCourse(course);
                return RedirectToAction("StudentCourse");
            }
            
            return View(course);
        }
        
        [HttpGet]
        public IActionResult EditCourse(int id)
        { 
            var showCourse = _courseRepository.GetCourse(id);

            return View(showCourse);
        }

        [HttpPost]
        public IActionResult EditCourse(StudentCourse course)
        {
            if (ModelState.IsValid)
            {
                StudentCourse courseChanges = _courseRepository.EditCourse(course);
                return RedirectToAction("StudentCourse");
            }

            return View(course);
        }

        [HttpGet]
        public IActionResult DeleteCourse(int id)
        {
            var deletedCourse = _courseRepository.GetCourse(id);

            return View(deletedCourse);
        }

        [HttpPost]
        public IActionResult DeleteCourse(StudentCourse course )
        {
            if (ModelState.IsValid)
            {
                StudentCourse deletedCourse = _courseRepository.DeleteCourse(course);
                return RedirectToAction("StudentCourse");
            }

            return View(course);
        }
    }
}
       