using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp.Service.Services;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace evdekinisatcom.MvcWebApp.WebMvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IAccountService _accountService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderController(ICartService cartService, IAccountService accountService, IOrderService orderService, IProductService productService)
        {
            _cartService = cartService;
            _accountService = accountService;
            _orderService = orderService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmAddress()
        {
            var user = await _accountService.Find(User.Identity.Name);

            var model = new AddressConfirmationViewModel
            {
                Address = user.Address
            };

            OrderViewModel order = new OrderViewModel()
            {
                BuyerId = user.Id,
                TotalPrice = 0,
                TotalQuantity = 0
            };
            await _orderService.CreateOrder(order);            

            return View(model);
        }

        

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var user = await _accountService.Find(User.Identity.Name);
            var cart = await _cartService.GetCartByUserId(user.Id);
            var cartItemList = await _cartService.GetAllCartItems(cart.Id);
            var cartItems = new List<CartItemViewModel>();
            decimal totalPrice = 0;
            foreach (var cartItem in cartItemList)
            {
                totalPrice += cartItem.Price;
                cartItems.Add(cartItem);
            }

            // Sipariş özeti için modeli hazırla
            CheckoutViewModel model = new CheckoutViewModel
            {
                CartItems = cartItems,
                TotalPrice = totalPrice
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            // Ödeme işlemleri simüle edilmesi          

            // Siparişin oluşturulması
            bool paymentSuccess = SimulatePaymentProcess(model);

            if (paymentSuccess)
            {
                var user = await _accountService.Find(User.Identity.Name);
                var cart = await _cartService.GetCartByUserId(user.Id);
                decimal totalPrice = 0;
                int totalQuantity = 0;
                var cartItemList = await _cartService.GetAllCartItems(cart.Id);
                // Sepetin Doğrulanması                
                var createdOrder = await _orderService.GetOrder(user.Id);
                foreach (var item in cartItemList)
                {

                    var product = await _productService.GetById(item.ProductId);
                    if (product.StockQuantity < item.Quantity)
                    {
                        TempData["ErrorMessage"] = "Ürün Satışta Değil!";
                        await _cartService.RemoveFromCartAsync(cart.Id, product.Id);
                        return RedirectToAction("Index","Cart",cart); // Sepet görüntüsüne geri dön
                    }
                    else
                    {

                        totalQuantity += item.Quantity;
                        totalPrice += item.Price;

                        OrderDetailViewModel orderDetail = new OrderDetailViewModel
                        {
                            OrderId = createdOrder.Id,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            UnitPrice = item.Price,
                            SellerId = product.SellerId,
                            ProductTitle = product.Title,
                        };

                        await _orderService.CreateOrderDetail(orderDetail);
                        //product içerisine alıcı id kaydedilmesi

                        product.BuyerId = createdOrder.BuyerId;

                        // Stok Güncellemesi

                        product.StockQuantity -= item.Quantity;
                        if (product.StockQuantity == 0)
                        {
                            product.IsSold = true;
                        }
                        await _productService.Update(product);

                        await _orderService.CreateOrderActivity(createdOrder.Id, "Sipariş Oluşturuldu", createdOrder.BuyerId, product.SellerId,item.Price);


                    }
                }

                           

                // Siparişin Güncellenmesi

                createdOrder.TotalQuantity = totalQuantity;
                createdOrder.TotalPrice = totalPrice;

                await _orderService.UpdateOrder(createdOrder);

                // Sepetin Temizlenmesi
                await _cartService.ClearCartAsync(cart.Id);
                return RedirectToAction("OrderConfirmation", createdOrder.Id);
            }
            return View();
        }

        public async Task<IActionResult> OrderConfirmation(int orderId)
        {
            //var order = await _orderService.GetOrder(orderId);
            //var orderDetailList = await _orderService.GetAllOrderDetails(order.Id);
            //foreach(var orderDetail in orderDetailList)
            //{
                
            //}
            //var orderActivity = new OrderActivityViewModel 
            //{
            //    OrderId = order.Id,
            //    BuyerId = order
            //};
            return View();
        }

        private bool SimulatePaymentProcess(CheckoutViewModel model)
        {
            // Ödeme işleminin başarılı olduğunu varsayıyoruz.
            return true;
        }
    }

}
