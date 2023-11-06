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
using Microsoft.Identity.Client;
using Microsoft.Exchange.WebServices.Data;

namespace evdekinisatcom.MvcWebApp_App.WebMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public AccountController(IAccountService service, ICartService cartService, IOrderService orderService)
        {
            _service = service;
            _cartService = cartService;
            _orderService = orderService;
        }
        [Authorize]
        public async Task< IActionResult> Index()
        {
            
            var currentUser = await _service.Find(User.Identity.Name);
            if(currentUser != null)
            {
                ViewBag.SellerActivity = await _orderService.GetAllSellerActivityByUserId(currentUser.Id);
                ViewBag.BuyerActivity = await _orderService.GetAllBuyerActivityByUserId(currentUser.Id);
                ViewBag.WithDrawals = await _service.GetWithdrawalsByUserId(currentUser.Id);
                return View(currentUser);
            }
            else
            {
                return RedirectToAction("Login");
            }
            
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

        [Authorize]
        [HttpGet]
        public IActionResult UpdateProfilePic()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfilePic(ProfileImageViewModel model, IFormFile profilePic)
        {
            var currentUser = await _service.Find(User.Identity.Name);            
            model.UserId = currentUser.Id;
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\userUploads\\users");
            var userPath = Path.Combine(uploadPath, currentUser.Username);
            uploadPath = userPath;

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Profil fotoğrafı için
            string profileFileExtension = Path.GetExtension(profilePic.FileName);
            string uniqueProfileFileName = $"{Guid.NewGuid()}{profileFileExtension}";
            var profilePath = Path.Combine(uploadPath, uniqueProfileFileName);
            using (var stream = new FileStream(profilePath, FileMode.Create))
            {
                await profilePic.CopyToAsync(stream);
            }
            model.ProfileImageUrl = "/userUploads/users/" + currentUser.Username + "/" + uniqueProfileFileName;

            
            await _service.UpdatePP(model);
            TempData["pictureMessage"] = "Profil fotoğrafınız başarıyla güncellendi!";
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

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _service.ChangePasswordAsync(User.Identity.Name, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                await _service.LogoutAsync();
                return RedirectToAction("PasswordChangedSuccessfully");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
        }


        public IActionResult PasswordChangedSuccessfully()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Withdraw()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(WithdrawViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _service.Find(User.Identity.Name);
                if (user == null)
                {
                    return NotFound($"'{user.Id}' ID'li kullanıcı bulunamadı.");
                }

                try
                {
                    
                    var message = await _service.Withdraw(user.Id, model.Amount, model.IBAN, model.RecipientName);                    
                    
                    if (message == "NO")
                    {
                        ModelState.AddModelError("", "Yetersiz Bakiye!");
                        return RedirectToAction("Withdraw", "Account");
                    }

                    if(message == "OK")
                    {
                        
                        return RedirectToAction("WithdrawSuccess");
                    }
                    
                }
                catch (Exception ex)
                {
                    
                    ModelState.AddModelError("", "Para çekme işlemi sırasında bir hata oluştu.");
                }
            }

            return View(model);
        }

        public IActionResult WithdrawSuccess()
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

