using EducationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.IO;

namespace EducationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="adm")]
    public class HomeController : Controller
    {

        private readonly EducationprojectContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(EducationprojectContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.TbVideos.Include(m => m.Matrial).Include(t => t.Teacher).Include(l => l.Level).ToListAsync());
        }
        public async Task<IActionResult> CreateVideo()
        {
            ViewBag.state = "إضافة فيديو";
            ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
            ViewBag.Teachers = await _context.TbTeachers.ToListAsync();
            ViewBag.Levels = await _context.TbLevels.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateVideo(TbVideo video)
        {
            //if (file is not null)
            //{
            //    string VideoUrl = Guid.NewGuid().ToString() + ".mp4";
            //    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads\Video", VideoUrl);
            //    using (var stream = System.IO.File.Create(filePaths))
            //    {
            //        await file.CopyToAsync(stream);
            //    }
            //    video.Url = VideoUrl;
            //}
            //else
            //{
            //    ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
            //    ViewBag.Teachers = await _context.TbTeachers.ToListAsync();
            //    ViewBag.Levels = await _context.TbLevels.ToListAsync();
            //    return View(video);
            //}
            if (!ModelState.IsValid)
            {
                ViewBag.state = "إضافة فيديو";
                ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
                ViewBag.Teachers = await _context.TbTeachers.ToListAsync();
                ViewBag.Levels = await _context.TbLevels.ToListAsync(); ;
                return View(video);
            }
            if (video.VideoId == 0)
                await _context.TbVideos.AddAsync(video);

            else
                _context.Entry(video).State = EntityState.Modified;

            _context.SaveChanges();
            return RedirectToAction(nameof(CreateVideo));
        }
        public async Task<IActionResult> EditVideo(int id)
        {
            ViewBag.state = "تعديل الفيديو";
            ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
            ViewBag.Teachers = await _context.TbTeachers.ToListAsync();
            ViewBag.Levels = await _context.TbLevels.ToListAsync();
            var vidoe = await _context.TbVideos.Include(m => m.Matrial).Include(l => l.Level).SingleOrDefaultAsync(i => i.VideoId == id);
            return View(nameof(CreateVideo), vidoe);
        }
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var v = await _context.TbVideos.FindAsync(id);
            _context.Remove(v);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AddTeacher()
        {
            ViewBag.teacher = "إضافة";
            ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
            ViewBag.teachers = await _context.TbTeachers.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTeacher(TbTeacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            if (teacher.TeacherId == 0)
                await _context.TbTeachers.AddAsync(teacher);
            else
                _context.Entry(teacher).State = EntityState.Modified;

            _context.SaveChanges();
            return Redirect("/Admin/Home/AddTeacher");
        }
        public IActionResult DeleteTeacher(int id)
        {
            _context.Remove(_context.TbTeachers.Find(id));
            _context.SaveChanges();
            return Redirect("/Admin/Home/AddTeacher");
        }
        public async Task<IActionResult> EditTeacher(int id)
        {
            ViewBag.teacher = "تعديل";
            ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
            ViewBag.teachers = await _context.TbTeachers.ToListAsync();
            return View(nameof(AddTeacher),await _context.TbTeachers.Include(t=>t.Matrial).SingleOrDefaultAsync(t=>t.TeacherId==id));
        }
        public IActionResult noSubscribe()
        {
            if (DateTime.Now.Day == 1)
            {
                var users = _userManager.Users.ToList();
                foreach (var item in users)
                {
                    if (_userManager.GetUserId(User) == item.Id && (User.IsInRole("adm")))
                        continue;
                    else
                        item.Subscribe = false;
                }
                _context.SaveChanges();
                return Redirect("/Admin/Users/GetAllUsers");
            }
            return View();

        }
        public IActionResult subscribe()
        {
            var users = _userManager.Users.ToList();
            foreach (var item in users)
            {
                if (_userManager.GetUserId(User) == item.Id && (User.IsInRole("adm")))
                    continue;
                else
                    item.Subscribe = true;
            }
            _context.SaveChanges();
            return Redirect("/Admin/Users/GetAllUsers");
        }
    }
}
