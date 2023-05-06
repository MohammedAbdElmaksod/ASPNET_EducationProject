using EducationProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace EducationProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly EducationprojectContext _context;

        public UsersController(SignInManager<ApplicationUser> signinManager, EducationprojectContext context)
        {

            _signinManager = signinManager;
            _context = context;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new UserModel { returnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            if (await _context.Users.FirstOrDefaultAsync(u => u.Code == userModel.Code) is null)
            {
                ModelState.AddModelError("Code", "الكود غير موجود او غير صحيح");
                return View(userModel);
            }
            if (!ModelState.IsValid)
                return View(userModel);
           var user= await _context.Users.FirstOrDefaultAsync(u=>u.UserName==userModel.UserName);
            if (user is null)
            {
                ModelState.AddModelError("UserName", "اسم المستخدم خطأ");
                return View(userModel);
            }
            var result = await _signinManager.PasswordSignInAsync(userModel.UserName, userModel.Password, true, false);
            if (userModel.returnUrl.IsNullOrEmpty())
                userModel.returnUrl = "~/";
            if (result.Succeeded)
            {
                return Redirect(userModel.returnUrl);
            }
            ModelState.AddModelError("Password", "كلمة السر غير صحيحة");
            return View(nameof(Login),userModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return Redirect("~/");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
