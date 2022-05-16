using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _V2__OnlineVideoCourseWebsite.Data;
using _V2__OnlineVideoCourseWebsite.Models;

namespace _V2__OnlineVideoCourseWebsite.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Topics
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Topic.Include(t => t.CourseOffering);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Topics/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Topic == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic
                .Include(t => t.CourseOffering)
                .FirstOrDefaultAsync(m => m.TopicId == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // GET: Topics/Create
        public IActionResult Create()
        {
            ViewData["CourseOfferingId"] = new SelectList(_context.CourseOffering, "CourseOfferingId", "CourseOfferingId");
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TopicId,Title,CourseOfferingId")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseOfferingId"] = new SelectList(_context.CourseOffering, "CourseOfferingId", "CourseOfferingId", topic.CourseOfferingId);
            return View(topic);
        }

        // GET: Topics/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Topic == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            ViewData["CourseOfferingId"] = new SelectList(_context.CourseOffering, "CourseOfferingId", "CourseOfferingId", topic.CourseOfferingId);
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TopicId,Title,CourseOfferingId")] Topic topic)
        {
            if (id != topic.TopicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.TopicId))
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
            ViewData["CourseOfferingId"] = new SelectList(_context.CourseOffering, "CourseOfferingId", "CourseOfferingId", topic.CourseOfferingId);
            return View(topic);
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Topic == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic
                .Include(t => t.CourseOffering)
                .FirstOrDefaultAsync(m => m.TopicId == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Topic == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Topic'  is null.");
            }
            var topic = await _context.Topic.FindAsync(id);
            if (topic != null)
            {
                _context.Topic.Remove(topic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(long id)
        {
          return (_context.Topic?.Any(e => e.TopicId == id)).GetValueOrDefault();
        }
    }
}
