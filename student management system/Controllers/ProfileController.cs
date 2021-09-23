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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace student_management_system.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IBioDataRepository _biodataRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProfileController(IBioDataRepository biodataRepository, ICourseRepository courseRepository, IImageRepository imageRepository, IWebHostEnvironment hostEnvironment)
        {
            _biodataRepository = biodataRepository;
            _courseRepository = courseRepository;
            _imageRepository = imageRepository;
            _hostEnvironment = hostEnvironment;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student = _biodataRepository.GetAllStudentsInfo().Where(b => b.StudentId == UserId);

            return View(student);
        }

        public IActionResult ProfileImage()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var image = _imageRepository.ShowImages().Where(b => b.ImageId == UserId);
            return View(image);
        }

        public IActionResult CreateProfileImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfileImage(ProfileImage model)
        {
            model.ImageId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                //saave images to wwwrooot/image
                string webRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                model.ImagePath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(webRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }

                //insert record
                _imageRepository.AddImage(model);
                 return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult DeleteProfileImage(string id)
        {
            var deletedImage = _imageRepository.GetImage(id);
            return View(deletedImage);
        }

        [HttpPost]
        public IActionResult DeleteProfileImage(ProfileImage model)
        {
            if (ModelState.IsValid)
            {
                ProfileImage deletedImage = _imageRepository.DeleteImage(model);
                return RedirectToAction("Index");
            }
            return View(model);
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
        public async Task<IActionResult> CreateBioData(Student model)
        {
            model.StudentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                //saave images to wwwrooot/image
                string webRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                model.ImagePath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(webRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }

                _biodataRepository.AddStudentInfo(model);
                return RedirectToAction("Index");
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
        public async Task<IActionResult> EditBioData(Student model)
        {
            if (ModelState.IsValid)
            { //saave images to wwwrooot/image
                string webRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                model.ImagePath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(webRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }

                _biodataRepository.EditStudentInfo(model);
                return RedirectToAction("Index");
            }
            
            return View(model);
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
                _courseRepository.EditCourse(course);
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
                _courseRepository.DeleteCourse(course);
                return RedirectToAction("StudentCourse");
            }

            return View(course);
        }
    }
}
       