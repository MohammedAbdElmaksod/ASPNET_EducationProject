using EducationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;

namespace EducationProject.Controllers
{
    public class MatrialsController : Controller
    {
        private readonly EducationprojectContext _context;
        private readonly UserManager<ApplicationUser> _manger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public MatrialsController(EducationprojectContext context, UserManager<ApplicationUser> manger, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _manger = manger;
            _signInManager = signInManager;
        }
        [Authorize(Roles = "adm,st1,ch1")]
        public async Task<IActionResult> FirstYearCHST()
        {

            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الأول/ كيمياء-منهج";
            return View(await _context.TbVideos.Include(a=>a.AssignmentLinks).Where(l => l.LevelId == 1 && l.MatrialId == 2 && !l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        [Authorize(Roles = "adm,st1,ch1")]
        public async Task<IActionResult> FirstYearCHRV()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الأول/ كيمياء-مراجعة";
            return View(await _context.TbVideos.Where(l => l.LevelId == 1 && l.MatrialId == 2 && l.Chapter.Contains("مراجعة")).ToListAsync());
        }
        [Authorize(Roles = "adm,st2,ch2")]
        public async Task<IActionResult> SecondYearCHST()
        {

            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الثانى/ كيمياء-منهج";
            return View(await _context.TbVideos.Where(l => l.LevelId == 2 && l.MatrialId == 4 && !l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        [Authorize(Roles = "adm,st2,ch2")]
        public async Task<IActionResult> SecondYearCHRV()
        {

            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الثانى/ كيمياء-مراجعة";
            return View(await _context.TbVideos.Where(l => l.LevelId == 2 && l.MatrialId == 4 && l.Chapter.Contains("مراجعة")).ToListAsync());


        }
        [Authorize(Roles = "adm,st3,ch3")]
        public async Task<IActionResult> ThirdYearCHST()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الثالث/ كيمياء-منهج";
            return View(await _context.TbVideos.Where(l => l.LevelId == 3 && l.MatrialId == 6 && !l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        [Authorize(Roles = "adm,st3,ch3")]
        public async Task<IActionResult> ThirdYearCHRV()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الثالث/ كيمياء-مراجعة";
            return View(await _context.TbVideos.Where(l => l.LevelId == 3 && l.MatrialId == 6 && l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        [Authorize(Roles = "adm,st1,bi1")]
        public async Task<IActionResult> FirstYearBIOST()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الأول/ أحياء-منهج";
            return View(await _context.TbVideos.Where(l => l.LevelId == 1 && l.MatrialId == 3 && !l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        [Authorize(Roles = "adm,st1,bi1")]
        public async Task<IActionResult> FirstYearBIORV()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الأول/ أحياء-مراجعة";
            return View(await _context.TbVideos.Where(l => l.LevelId == 1 && l.MatrialId == 3 && l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        [Authorize(Roles = "adm,st2,bi2")]
        public async Task<IActionResult> SecondYearBIOST()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الثانى/ أحياء-منهج";
            return View(await _context.TbVideos.Where(l => l.LevelId == 2 && l.MatrialId == 5 && !l.Chapter.Contains("مراجعة")).ToListAsync());



        }
        [Authorize(Roles = "adm,st2,bi2")]
        public async Task<IActionResult> SecondYearBIORV()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الثانى/ أحياء-مراجعة";
            return View(await _context.TbVideos.Where(l => l.LevelId == 2 && l.MatrialId == 5 && l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        [Authorize(Roles = "adm,st3,bi3")]
        public async Task<IActionResult> ThirdYearBIOST()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الثالث/ أحياء-منهج";
            return View(await _context.TbVideos.Where(l => l.LevelId == 3 && l.MatrialId == 7 && !l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        [Authorize(Roles = "adm,st3,bi3")]
        public async Task<IActionResult> ThirdYearBIORV()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الثالث/ أحياء-مراجعة";
            return View(await _context.TbVideos.Where(l => l.LevelId == 3 && l.MatrialId == 7 && l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        [Authorize(Roles = "adm,st3,ge3")]
        public async Task<IActionResult> ThirdYearGEST()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الثالث/ جيولوجيا منهج";
            return View(await _context.TbVideos.Where(l => l.LevelId == 3 && l.MatrialId == 10 && !l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        [Authorize(Roles = "adm,st3,ge3")]
        public async Task<IActionResult> ThirdYearGERV()
        {
            var user = await _manger.GetUserAsync(User);
            if (user.Subscribe == false)
                return Redirect("/Users/AccessDenied");

            ViewBag.year = "الصف الثالث/ جيولوجيا مراجعة";
            return View(await _context.TbVideos.Where(l => l.LevelId == 3 && l.MatrialId == 10 && l.Chapter.Contains("مراجعة")).ToListAsync());

        }
        public async Task<IActionResult> sendAssignment()
        {
            ViewBag.Teachers = await _context.TbTeachers.ToListAsync();
            ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
            ViewBag.Levels = await _context.TbLevels.ToListAsync();
            ViewBag.Assignment = await _context.TbAssignmentLinks.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> sendAssignment(AssignmentsDone assignment, IFormFile file)
        {
            if (assignment is not null)
            {
                if (file is not null)
                {
                    string imageUrl = Guid.NewGuid().ToString() + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads\Images", imageUrl);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    assignment.imgUrl = imageUrl;

                }
                else
                {
                    ViewBag.Teachers = await _context.TbTeachers.ToListAsync();
                    ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
                    ViewBag.Levels = await _context.TbLevels.ToListAsync();
                    ViewBag.Assignment = await _context.TbAssignmentLinks.ToListAsync();
                    ModelState.AddModelError("imgUrl", "يجب ادخال الصوره");
                    return View(assignment);
                }

                assignment.userId = (await _manger.GetUserAsync(User))?.Id;
                assignment.Done = true;
                await _context.AssignmentsDone.AddAsync(assignment);
                _context.SaveChanges();
                return Redirect("/");

            }
            ViewBag.Teachers = await _context.TbTeachers.ToListAsync();
            ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
            ViewBag.Levels = await _context.TbLevels.ToListAsync();
            ViewBag.Assignment = await _context.TbAssignmentLinks.ToListAsync();
            return View(assignment);
        }
    }
}
