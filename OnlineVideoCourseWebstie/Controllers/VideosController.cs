#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineVideoCourseWebsite.Data;
using OnlineVideoCourseWebsite.Models;
using OnlineVideoCourseWebsite.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace OnlineVideoCourseWebsite.Controllers
{
    [Authorize(Roles = "Admin,Instructor")]
    public class VideosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Video.ToListAsync());
        }

        // GET: Videos/Details/  ->   /vid?id=5&topicid=1
        [HttpGet("vid")]
        public async Task<IActionResult> Details(long? id, long topicid)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Video
                .FirstOrDefaultAsync(m => m.VideoId == id);
            if (video == null)
            {
                return NotFound();
            }

            var course = await _context.Course
              .Include(m => m.CourseOfferings).Include("CourseOfferings.Topics.TopicVideos")
              .Include("CourseOfferings.Topics.TopicVideos.Video")
              .FirstOrDefaultAsync();

            var topic = await _context.Topic.Where(m => m.TopicId == topicid)
                .Include(m => m.Resources)
                .FirstOrDefaultAsync();

            var videoViewModel = new VideoViewModel()
            {
                Course = course,
                Resources = topic.Resources,
                Video = video
            };

            return View(videoViewModel);
        }

        // GET: Videos1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Videos1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoId,Title,Description,Duration,Thumbnail,URL")] Video video)
        {
            if (ModelState.IsValid)
            {
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(video);
        }

        // GET: Videos1/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Video.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        // POST: Videos1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("VideoId,Title,Description,Duration,Thumbnail,URL")] Video video)
        {
            if (id != video.VideoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.VideoId))
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
            return View(video);
        }

        // GET: Videos1/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Video
                .FirstOrDefaultAsync(m => m.VideoId == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Videos1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var video = await _context.Video.FindAsync(id);
            _context.Video.Remove(video);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(long id)
        {
            return _context.Video.Any(e => e.VideoId == id);
        }
    }
}
