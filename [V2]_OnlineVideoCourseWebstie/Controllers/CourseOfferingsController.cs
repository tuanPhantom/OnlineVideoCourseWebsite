#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _V2__OnlineVideoCourseWebstie.Data;
using _V2__OnlineVideoCourseWebstie.Models;

namespace _V2__OnlineVideoCourseWebstie.Controllers
{
    public class CourseOfferingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseOfferingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseOfferings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseOffering.Include(c => c.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseOfferings/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseOffering = await _context.CourseOffering
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.CourseOfferingId == id);
            if (courseOffering == null)
            {
                return NotFound();
            }

            return View(courseOffering);
        }

        // GET: CourseOfferings/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "Title");
            return View();
        }

        // POST: CourseOfferings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseOfferingId,Year,CreatedDate,OpenDate,CourseId")] CourseOffering courseOffering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseOffering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "Title", courseOffering.CourseId);
            return View(courseOffering);
        }

        // GET: CourseOfferings/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseOffering = await _context.CourseOffering.FindAsync(id);
            if (courseOffering == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "Title", courseOffering.CourseId);
            return View(courseOffering);
        }

        // POST: CourseOfferings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CourseOfferingId,Year,CreatedDate,OpenDate,CourseId")] CourseOffering courseOffering)
        {
            if (id != courseOffering.CourseOfferingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseOffering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseOfferingExists(courseOffering.CourseOfferingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "Title", courseOffering.CourseId);
            return View(courseOffering);
        }

        // GET: CourseOfferings/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseOffering = await _context.CourseOffering
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.CourseOfferingId == id);
            if (courseOffering == null)
            {
                return NotFound();
            }

            return View(courseOffering);
        }

        // POST: CourseOfferings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var courseOffering = await _context.CourseOffering.FindAsync(id);
            _context.CourseOffering.Remove(courseOffering);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseOfferingExists(long id)
        {
            return _context.CourseOffering.Any(e => e.CourseOfferingId == id);
        }
    }
}
