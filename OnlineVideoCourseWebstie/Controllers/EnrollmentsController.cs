#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineVideoCourseWebsite.Common;
using OnlineVideoCourseWebsite.Data;
using OnlineVideoCourseWebsite.Models;
using OnlineVideoCourseWebsite.Models.ViewModels;

namespace OnlineVideoCourseWebsite.Controllers
{
    [Authorize(Roles = "Admin,Instructor,Student")]
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enrollment.Include(e => e.CourseOffering).Include(e => e.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.CourseOffering)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }


        [HttpGet("Enrollments/Create/")]
        // GET: Enrollments/Create/?courseId=5&haveEnrolledAtLeastOnce=true&courseOfferingId=2
        public IActionResult Create(long courseId, bool haveEnrolledAtLeastOnce, long courseOfferingId)
        {
            //long courseId = JsonConvert.DeserializeObject<long>(TempData["courseId"].ToString());
            //List<CourseOffering> courseOfferings = _context.CourseOffering.Where(m => m.CourseId == CourseId)
            //    .Where(m => m.Enrollments.Where(m => m.UserId == BinPattern.Bin["uid"].ToString()).FirstOrDefault() == null)
            //    .ToList();
            List<CourseOffering> CourseOfferings;
            //if ((bool)BinPattern.Bin["haveEnrolledAtLeastOnce"] == false)
            if (!haveEnrolledAtLeastOnce)
            {
                CourseOfferings = _context.CourseOffering.Where(m => m.CourseId == courseId).ToList();
            }
            else
            {
                //CourseOfferings = _context.CourseOffering.Where(m => m.CourseOfferingId == JsonConvert.DeserializeObject<long>(TempData["CourseOfferingId"].ToString())).ToList();
                CourseOfferings = _context.CourseOffering.Where(m => m.CourseOfferingId == courseOfferingId).ToList();
            }
            ViewBag.CourseOfferingId = new SelectList(CourseOfferings, "CourseOfferingId", "Year");

            var course = _context.Course.Where(m => m.CourseId == courseId).FirstOrDefault();
            ViewData["courseName"] = course.Title;
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,CourseOfferingId")] Enrollment enrollment)
        {
            enrollment.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            enrollment.User = await _context.User.Where(m => m.Id == enrollment.UserId).FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                enrollment.CourseOffering = await _context.CourseOffering.Where(m => m.CourseOfferingId == enrollment.CourseOfferingId).FirstOrDefaultAsync();
                return Redirect("/course?id=" + enrollment.CourseOffering.CourseId + "&CourseOfferingId=" + enrollment.CourseOfferingId);
            }
            ViewBag.CourseOfferingId = new SelectList(_context.CourseOffering, "CourseOfferingId", "Year", enrollment.CourseOfferingId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewBag.CourseOfferingId = new SelectList(_context.CourseOffering, "CourseOfferingId", "Year", enrollment.CourseOfferingId);
            ViewBag.UserId = new SelectList(_context.User, "Id", "UserName", enrollment.UserId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("EnrollmentId,Grade,UserId,CourseOfferingId")] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/course?id=" + enrollment.CourseOffering.CourseId + "&CourseOfferingId=" + enrollment.CourseOfferingId);
            }
            ViewBag.CourseOfferingId = new SelectList(_context.CourseOffering, "CourseOfferingId", "Year", enrollment.CourseOfferingId);
            ViewBag.UserId = new SelectList(_context.User, "Id", "UserName", enrollment.UserId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.CourseOffering)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);
            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(long id)
        {
            return _context.Enrollment.Any(e => e.EnrollmentId == id);
        }
    }
}
