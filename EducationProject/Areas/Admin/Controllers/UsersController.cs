using EducationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography;

namespace EducationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "adm")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly EducationprojectContext _context;

        public UsersController(UserManager<ApplicationUser> userManager, EducationprojectContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Register()
        {
            ViewBag.Level = _context.TbLevels.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel userManager)
        {
            var user = new ApplicationUser
            {
                FullName = userManager.FullName,
                UserName = userManager.UserName,
                Code = userManager.Code,
                Subscribe = userManager.Subscribe,
                LevelId = userManager.LevelId,
            };

            var role = userManager.Code.ToLower().Substring(0, 3);
            ViewBag.Level = _context.TbLevels.ToList();
            try
            {
                var result = await _userManager.CreateAsync(user, userManager.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role);
                    var student = new TbStudent
                    {
                        StudentId = Guid.NewGuid().ToString(),
                        StudentFullName = userManager.FullName,
                        UserName = userManager.UserName,
                        Code = userManager.Code,
                        subscribe = userManager.Subscribe,
                        LevelId = userManager.LevelId,
                    };
                    await _context.TbStudents.AddAsync(student);
                    _context.SaveChanges();
                    return Redirect(nameof(Register));
                }
                else
                {
                    ModelState.AddModelError("Subscribe", result.Errors.FirstOrDefault().Description);
                }
                return View(nameof(Register), userManager);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        public async Task<IActionResult> EditUser(string userName)
        {
            ViewBag.level = _context.TbLevels.ToList();
            var user = await _userManager.FindByNameAsync(userName);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(UserModel User)
        {
            var user = await _userManager.FindByNameAsync(User.UserName);
            if (user == null) { return View("Error"); }
            user.Subscribe = User.Subscribe;
            user.FullName = User.FullName;
            user.UserName = User.UserName;
            user.Code = User.Code;
            await _userManager.AddPasswordAsync(user, User.Password);
            _context.SaveChanges();


            return RedirectToAction(nameof(GetAllUsers));
        }
        public async Task<IActionResult> DeleteUser(string userName)
        {
            await _userManager.DeleteAsync(await _userManager.FindByNameAsync(userName));
            return Redirect("/Admin/Users/GetAllUsers");
        }
    }
}
