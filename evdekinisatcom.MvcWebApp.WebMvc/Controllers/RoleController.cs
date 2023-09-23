using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using evdekinisatcom.MvcWebApp.DataAccess.Identity.Models;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;

namespace evdekinisatcom.MvcWebApp_App.WebMvc.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var model = roles.Select(r => new RoleViewModel()
            {
                Id = r.Id,
                RoleName = r.Name,
                CreatedDate = r.CreatedDate,
            });
            return View(model);
        }
        //[Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            var role = new AppRole()
            {
                Name = model.RoleName,
            };

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var usersInRole = new List<AppUser>();
            var usersOutRole = new List<AppUser>();

            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    usersInRole.Add(user); //Rolde olanları getirir
                }
                else
                {
                    usersOutRole.Add(user); //Rolde olmayanlarını getirir
                }
            }
            
            UsersInOrOutRoleViewModel model = new UsersInOrOutRoleViewModel()
            {
                Role = role,
                UsersInRole = usersInRole,
                UsersOutRole = usersOutRole
            };
            return View(model);
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id, List<string> UserIdsToDelete, List<string> UserIdsToAdd)
        {
            var role = await _roleManager.FindByIdAsync(id);

            // Rolde olmayan kullanıcıları ekle
            foreach (var userId in UserIdsToAdd)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null && !await _userManager.IsInRoleAsync(user, role.Name))
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
            }

            // Rolde olan kullanıcıları silin
            foreach (var userId in UserIdsToDelete)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }

            return RedirectToAction("Edit", "Role", new { Id = role.Id });
        }
    }
}
