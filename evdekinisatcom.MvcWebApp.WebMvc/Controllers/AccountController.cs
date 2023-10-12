using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using evdekinisatcom.MvcWebApp.DataAccess.Identity.Models;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Service.Services;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;

namespace evdekinisatcom.MvcWebApp_App.WebMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly ICartService _cartService;

        public AccountController(IAccountService service, ICartService cartService)
        {
            _service = service;
            _cartService = cartService;
        }
        [Authorize]
        public async Task< IActionResult> Index()
        {
            var currentUser = await _service.Find(User.Identity.Name);
            return View(currentUser);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            string msg = await _service.CreateUserAsync(model);

            if (msg == "OK")
            {                
                
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", msg);
            }

            return View(model);
        }
        public IActionResult Login(string? returnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var msg = await _service.FindByNameAsync(model);

            if (msg == "user not found")
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(model);
            }
            else if (msg == "OK")
            {

                return Redirect(model.ReturnUrl ?? "~/");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditAddress()
        {
            var user = await _service.Find(User.Identity.Name);
            var model = new AddressEditViewModel
            {
                Address = user.Address
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAddress(AddressEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _service.Find(User.Identity.Name);
                user.Address = model.Address;
                await _service.Update(user);
                return RedirectToAction("Index","Account");
            }
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UpdatePhone()
        {
            var currentUser = await _service.Find(User.Identity.Name);
            var model = new UpdatePhoneViewModel
            {
                PhoneNumber = currentUser.PhoneNumber
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePhone(UpdatePhoneViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUser = await _service.Find(User.Identity.Name);
            currentUser.PhoneNumber = model.PhoneNumber;

            await _service.Update(currentUser);

            TempData["SuccessMessage"] = "Telefon numaranız başarıyla güncellendi!";
            return RedirectToAction("Profile"); // Varsayılan profil sayfasına yönlendirme
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

