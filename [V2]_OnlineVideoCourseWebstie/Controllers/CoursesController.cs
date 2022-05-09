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
using _V2__OnlineVideoCourseWebstie.Models.ViewModels;

namespace _V2__OnlineVideoCourseWebstie.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Course.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.Where(m => m.CourseId == id)
                .Include(m => m.Topics).Include("Topics.TopicVideos")
                .Include("Topics.TopicVideos.Video")
                .FirstOrDefaultAsync();

            //var course = await _context.Course.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            //foreach (var topic in _context.Topic)
            //{
            //    if (topic.CourseId == course.CourseId)
            //    {
            //        foreach (var topicvideo in _context.TopicVideo)
            //        {
            //            if (topicvideo.TopicId == topic.TopicId)
            //            {
            //                foreach (var video in _context.Video)
            //                {
            //                    if (video.VideoId == topicvideo.VideoId)
            //                    {
            //                        if (!topic.TopicVideos.Contains(topicvideo))
            //                        {
            //                            topicvideo.Video = video;
            //                            topicvideo.Topic = topic;
            //                            topic.TopicVideos.Add(topicvideo);
            //                        }
            //                        if (!course.Topics.Contains(topic))
            //                        {
            //                            course.Topics.Add(topic);
            //                        }
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}


            // inject to viewModels
            var courseViewModel = new CourseViewModel()
            {
                Course = course,
                Topics = course.Topics
            };
            return View(courseViewModel);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,Title,Description,ImageUrl,MarqueeImageUrl")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CourseId,Title,Description,ImageUrl,MarqueeImageUrl")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
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
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(long id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}
