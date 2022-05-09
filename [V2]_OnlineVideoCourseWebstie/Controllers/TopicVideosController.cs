#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _V2__OnlineVideoCourseWebsite.Data;
using _V2__OnlineVideoCourseWebsite.Models;
using Microsoft.AspNetCore.Authorization;

namespace _V2__OnlineVideoCourseWebsite.Controllers
{
    [Authorize(Roles = "Admin,Instructor")]
    public class TopicVideosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopicVideosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TopicVideos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TopicVideo.Include(t => t.Video);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TopicVideos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicVideo = await _context.TopicVideo
                .Include(t => t.Video)
                .FirstOrDefaultAsync(m => m.TopicVideoId == id);
            if (topicVideo == null)
            {
                return NotFound();
            }

            return View(topicVideo);
        }

        // GET: TopicVideos/Create
        public IActionResult Create()
        {
            ViewData["VideoId"] = new SelectList(_context.Video, "VideoId", "VideoId");
            return View();
        }

        // POST: TopicVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TopicVideoId,TopicId,VideoId")] TopicVideo topicVideo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topicVideo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VideoId"] = new SelectList(_context.Video, "VideoId", "VideoId", topicVideo.VideoId);
            return View(topicVideo);
        }

        // GET: TopicVideos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicVideo = await _context.TopicVideo.FindAsync(id);
            if (topicVideo == null)
            {
                return NotFound();
            }
            ViewData["VideoId"] = new SelectList(_context.Video, "VideoId", "VideoId", topicVideo.VideoId);
            return View(topicVideo);
        }

        // POST: TopicVideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TopicVideoId,TopicId,VideoId")] TopicVideo topicVideo)
        {
            if (id != topicVideo.TopicVideoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topicVideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicVideoExists(topicVideo.TopicVideoId))
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
            ViewData["VideoId"] = new SelectList(_context.Video, "VideoId", "VideoId", topicVideo.VideoId);
            return View(topicVideo);
        }

        // GET: TopicVideos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicVideo = await _context.TopicVideo
                .Include(t => t.Video)
                .FirstOrDefaultAsync(m => m.TopicVideoId == id);
            if (topicVideo == null)
            {
                return NotFound();
            }

            return View(topicVideo);
        }

        // POST: TopicVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var topicVideo = await _context.TopicVideo.FindAsync(id);
            _context.TopicVideo.Remove(topicVideo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicVideoExists(long id)
        {
            return _context.TopicVideo.Any(e => e.TopicVideoId == id);
        }
    }
}
