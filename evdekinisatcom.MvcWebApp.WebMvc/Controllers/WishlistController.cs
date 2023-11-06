using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace evdekinisatcom.MvcWebApp.WebMvc.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly IAccountService _accountService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public WishlistController(IWishlistService wishlistService, IAccountService accountService, IProductService productService, IOrderService orderService)
        {
            _wishlistService = wishlistService;
            _accountService = accountService;
            _productService = productService;
            _orderService = orderService;
        }

        // Sepeti görüntüle
        [Authorize]
        public async Task<IActionResult> Index()
        {


            var user = await _accountService.Find(User.Identity.Name);
            var wishlist = await _wishlistService.GetWishlistByUserId(user.Id);
            // kullanıcının idsine göre Wishlist itemları getirme getirme
            var wishlistItems = await _wishlistService.GetAllWishlistItems(wishlist.Id);
            return View(wishlistItems);


        }

        //Sepete ürün ekle
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToWishlist(int id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                try
                {
                    var user = await _accountService.Find(User.Identity.Name);

                    var product = await _productService.GetById(id);
                    if (product != null && product.SellerId == user.Id)
                    {
                        TempData["ErrorMessage"] = "Kendi ürününüzü listeye ekleyemezsiniz!";
                        return RedirectToAction("Index");
                    }
                    else
                    {



                        var wishlist = await _wishlistService.GetWishlistByUserId(user.Id);
                        WishlistItemViewModel model = new WishlistItemViewModel()
                        {
                            WishlistId = wishlist.Id,
                            ProductId = product.Id,
                            ProductImg = product.HeaderImageUrl,
                            Price = product.Price,                            
                            Title = product.Title                           

                        };



                        await _wishlistService.AddToWishlistAsync(model);
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    ModelState.AddModelError("", "Ürün listeye eklenirken bir hata oluştu.");
                    return View("Error");
                }
            }
        }


        //Sepetten ürün çıkar



        [HttpPost]
        public async Task<IActionResult> RemoveFromWishlist(int wishlistId, int productId)
        {
            try
            {
                await _wishlistService.RemoveFromWishlistAsync(wishlistId, productId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                ModelState.AddModelError("", "Ürün sepetten silinirken bir hata oluştu.");
                return View("Error");
            }
        }


    }
}
