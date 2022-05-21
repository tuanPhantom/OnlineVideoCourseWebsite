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
using Microsoft.AspNetCore.Authorization;
using OnlineVideoCourseWebsite.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace OnlineVideoCourseWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await GetUserRoles(user);
                var model = new UserViewModel
                {
                    User = user,
                    Role = roles.ToList()[0]
                };
                userViewModels.Add(model);
            }
            return View(userViewModels);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await GetUserRoles(user);
            var model = new UserViewModel
            {
                User = user,
                Role = roles.ToList()[0]
            };

            return View(model);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var model = new UserViewModel();
            ViewBag.Roles = new SelectList(_roleManager.Roles, "Name", "Name");
            return View(model);
        }

        // Model as parameter
        [BindProperties]
        public class GetRequest
        {
            public User User { get; set; }
            public string Role { get; set; }
        }


        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GetRequest getRequest)
        {
            var user = getRequest.User;

            if (ModelState.IsValid)
            {
                //await _userManager.CreateAsync(user, user.PasswordHash);
                _context.Add(user);
                await _context.SaveChangesAsync();
                await _userManager.AddToRoleAsync(user, getRequest.Role);
                await _userManager.UpdateAsync(user);

                return RedirectToAction(nameof(Index));
            }

            var model = new UserViewModel();
            ViewBag.Roles = new SelectList(_roleManager.Roles, "Name", "Name");
            return View(model);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await GetUserRoles(user);
            var model = new UserViewModel
            {
                User = user,
                Role = roles.ToList()[0]
            };

            ViewBag.Roles = new SelectList(_roleManager.Roles, "Name", "Name", model.Role);
            return View(model);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, GetRequest getRequest)
        {
            var user = getRequest.User;
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                // delete old role then add new one
                var oldRole = await GetUserRoles(user);
                await _userManager.RemoveFromRoleAsync(user, oldRole[0]);
                await _userManager.AddToRoleAsync(user, getRequest.Role);
                await _userManager.UpdateAsync(user);

                return RedirectToAction(nameof(Index));
            }

            var roles = await GetUserRoles(user);
            var model = new UserViewModel
            {
                User = user,
                Role = roles.ToList()[0]
            };

            ViewBag.Roles = new SelectList(_roleManager.Roles, "Name", "Name", model.Role);
            return View(model);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await GetUserRoles(user);
            var model = new UserViewModel
            {
                User = user,
                Role = roles.ToList()[0]
            };
            return View(model);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        private async Task<List<string>> GetUserRoles(User user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        private async Task<List<string>> GetAllRoles()
        {
            var list = new List<string>();
            var roles = await _roleManager.Roles.ToListAsync();
            foreach (var role in roles)
            {
                list.Add(role.Name);
            }
            return list;
        }
    }
}
