using System.Threading.Tasks;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using student_management_system.Models;
//using IdentityUser = Microsoft.AspNet.Identity.EntityFramework.IdentityUser;

namespace student_management_system.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(student_management_system.Models.Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.FirstName
                };

                var data = await userManager.CreateAsync(user, model.Password);
                if (data.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "student");
                }

                foreach (var error in data.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
           
            return View(model);
        }




        public IActionResult Login()
        {
            return View();
        }
    }
}
