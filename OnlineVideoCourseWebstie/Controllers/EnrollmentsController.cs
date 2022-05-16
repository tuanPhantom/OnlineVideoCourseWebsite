﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            long id = JsonConvert.DeserializeObject<long>(TempData["CourseId"].ToString());
            List<CourseOffering> CourseOfferings = _context.CourseOffering.Where(m => m.CourseId == id).ToList();
            ViewBag.CourseOfferingId = new SelectList(CourseOfferings, "CourseOfferingId", "Year");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,CourseOfferingId")] Enrollment enrollment)
        {
            enrollment.UserId = TempData["userId"].ToString();
            enrollment.User = await _context.User.Where(m => m.Id == enrollment.UserId).FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                enrollment.CourseOffering = await _context.CourseOffering.Where(m => m.CourseOfferingId == enrollment.CourseOfferingId).FirstOrDefaultAsync();
                return Redirect(TempData["url"].ToString());
            }
            ViewBag.CourseOfferingId = new SelectList(_context.CourseOffering, "CourseOfferingId", "Year", enrollment.CourseOfferingId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "UserName", enrollment.UserId);
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
                return Redirect(TempData["url"].ToString());
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
