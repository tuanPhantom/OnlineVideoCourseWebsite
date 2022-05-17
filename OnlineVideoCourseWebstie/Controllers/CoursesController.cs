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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using OnlineVideoCourseWebsite.Common;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.Extensions;

namespace OnlineVideoCourseWebsite.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CoursesController> _logger;
        private readonly UserManager<User> _userManager;

        public CoursesController(ILogger<CoursesController> logger, ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        private async Task<User> FindUser()
        {
            User user = null;
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                string userId = claim.Value;
                user = await _userManager.FindByIdAsync(userId);
            }
            return user;
        }

        private async Task<string> FindUserRole(User user)
        {
            if (user == null) return null;
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles != null && roles.Count > 0 ? roles[0] : null;
            return role;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _context.Course.ToListAsync();

            User user = await FindUser();
            string role = await FindUserRole(user);

            CoursesDashBoardViewModel coursesDashBoardViewModel = new CoursesDashBoardViewModel()
            {
                Courses = courses,
                Role = role
            };
            return View(coursesDashBoardViewModel);
        }

        // GET: Courses/Details/5
        [HttpGet("details")]
        [Authorize(Roles = "Admin,Instructor,Student")]
        public async Task<IActionResult> Details(long? id, long? CourseOfferingId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.Where(m => m.CourseId == id)
                .Include(m => m.CourseOfferings).Include("CourseOfferings.Topics.TopicVideos")
                .Include("CourseOfferings.Topics.TopicVideos.Video")
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            // check enrollment
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (userId == null || currentUser == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollment.Where(m => m.User == currentUser)
                .Where(m => m.CourseOffering.CourseId == id)
                .ToListAsync();

            if (enrollments == null || enrollments.Where(m => (m.CourseOfferingId != CourseOfferingId) && CourseOfferingId != null).ToList().Count == enrollments.Count)
            {
                TempData["courseId"] = JsonConvert.SerializeObject(id);
                TempData["userId"] = userId;
                TempData["courseName"] = course.Title;
                TempData["url"] = Request.GetDisplayUrl();
                //BinPattern.Bin["uid"] = userId;
                if (enrollments.Count == 0)
                {
                    BinPattern.Bin["haveEnrolledAtLeastOnce"] = false;
                }
                else
                {
                    BinPattern.Bin["haveEnrolledAtLeastOnce"] = true;
                    TempData["CourseOfferingId"] = JsonConvert.SerializeObject(CourseOfferingId);
                }
                return Redirect("/Enrollments/Create/");
            }

            //var course = await _context.Course.FindAsync(id);
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

            dynamic courseOffering;
            if (CourseOfferingId == null)
            {
                List<CourseOffering> courseOfferings = await _context.CourseOffering.Where(m => m.CourseId == id)
                .Where(m => m.Enrollments.Where(m => m.UserId == userId).FirstOrDefault() != null)
                .ToListAsync();
                CourseOfferingDescComparer comparer = new CourseOfferingDescComparer();
                courseOfferings.Sort(comparer);
                courseOffering = courseOfferings[0];
            }
            else
            {
                courseOffering = await _context.CourseOffering.Where(m => m.CourseOfferingId == CourseOfferingId).FirstOrDefaultAsync();
            }

            // inject to viewModels
            var courseViewModel = new CourseViewModel()
            {
                Course = course,
                CourseOffering = courseOffering
            };

            return View(courseViewModel);
        }

        // GET: Courses/Create
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Instructor")]
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
        [Authorize(Roles = "Admin,Instructor")]
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
        [Authorize(Roles = "Admin,Instructor")]
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
        [Authorize(Roles = "Admin,Instructor")]
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
        [Authorize(Roles = "Admin,Instructor")]
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
