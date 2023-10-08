using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace evdekinisatcom.MvcWebApp.WebMvc.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IAccountService _accountService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public CartController(ICartService cartService, IAccountService accountService, IProductService productService, IOrderService orderService)
        {
            _cartService = cartService;
            _accountService = accountService;
            _productService = productService;
            _orderService = orderService;
        }

        // Sepeti görüntüle
        [Authorize]
        public async Task<IActionResult> Index()
        {


            var user = await _accountService.Find(User.Identity.Name);
            var cart = await _cartService.GetCartByUserId(user.Id);
            // kullanıcının idsine göre cart itemları getirme getirme
            var cartItems = await _cartService.GetAllCartItems(cart.Id);
            return View(cartItems);


        }

        //Sepete ürün ekle

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
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
                    if (product.SellerId == user.Id)
                    {
                        TempData["ErrorMessage"] = "Kendi ürününüzü sepete ekleyemezsiniz!";
                        return RedirectToAction("Index");
                    }
                    else
                    {



                        var cart = await _cartService.GetCartByUserId(user.Id);
                        CartItemViewModel model = new CartItemViewModel()
                        {
                            CartId = cart.Id,
                            ProductId = product.Id,
                            Price = product.Price,
                            Quantity = product.StockQuantity,
                            Title = product.Title,
                            SellerUsername = product.SellerUsername

                        };



                        await _cartService.AddToCartAsync(model);
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    ModelState.AddModelError("", "Ürün sepete eklenirken bir hata oluştu.");
                    return View("Error");
                }
            }
        }


        //Sepetten ürün çıkar



        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartId, int productId)
        {
            try
            {
                await _cartService.RemoveFromCartAsync(cartId, productId);
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
