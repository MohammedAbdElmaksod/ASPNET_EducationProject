using EducationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace EducationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "adm")]
    public class AssignmentController : Controller
    {
        private readonly EducationprojectContext _context;

        public AssignmentController(EducationprojectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Assignment()
        {
            return View(await _context.TbAssignmentLinks.Include(v=>v.video).Include(a => a.Matrial).Include(l => l.Level).Include(t => t.Teacher).ToListAsync());
        }
        public async Task<IActionResult> AssignmentDone()
        {
            return View(await _context.AssignmentsDone.Include(l=>l.level).Include(t=>t.teacher).Include(s => s.StudentUser).Include(a => a.Matrial).Include(l => l.Assignment).ToListAsync());
            
        }

        public async Task<IActionResult> CreateAssignment()
        {
            ViewBag.state = "Create Assignment";
            ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
            ViewBag.Teachers = await _context.TbTeachers.ToListAsync();
            ViewBag.Levels = await _context.TbLevels.ToListAsync();
            ViewBag.Videos = await _context.TbVideos.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAssignment(TbAssignmentLink assignment)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
                    ViewBag.Teachers = await _context.TbTeachers.ToListAsync();
                    ViewBag.Levels = await _context.TbLevels.ToListAsync();
                    ViewBag.Videos = await _context.TbVideos.ToListAsync();

                }
                catch { }
                return View(assignment);
            }
            try
            {
                if (assignment.AssignmentId == 0)
                    await _context.TbAssignmentLinks.AddAsync(assignment);
                else
                    _context.Entry(assignment).State = EntityState.Modified;

                _context.SaveChanges();
            }
            catch { }

            return RedirectToAction(nameof(CreateAssignment));
        }
        public async Task<IActionResult> EditAssignment(int id)
        {
            ViewBag.state = "Edit Assignment";
            ViewBag.matrilas = await _context.TbMatrials.ToListAsync();
            ViewBag.Teachers = await _context.TbTeachers.ToListAsync();
            ViewBag.Levels = await _context.TbLevels.ToListAsync();
            ViewBag.Videos = await _context.TbVideos.ToListAsync();
            var assignment = await _context.TbAssignmentLinks.Include(l => l.Level).Include(t => t.Teacher).SingleOrDefaultAsync(a => a.AssignmentId == id);
            return View(nameof(CreateAssignment), assignment);
        }
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            _context.TbAssignmentLinks.Remove(await _context.TbAssignmentLinks.FindAsync(id));
            _context.SaveChanges();
            return RedirectToAction(nameof(Assignment));
        }
        public IActionResult showImg(string src)
        {
            ViewBag.img = src;
            return View();
        }
    }
}
