using evdekinisatcom.MvcWebApp.Entity.Entities;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp.Service.Services;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            //cart item idlernin toplamı order number için
            int number = 0;
            
            foreach (var cartItem in cartItemList)
            {
                number += cartItem.Id;
                totalPrice += cartItem.Price;
                cartItems.Add(cartItem);
            }

            var orderNumber = GenerateOrderNumber(cart.Id,number);

            // Siparişi oluştur
            OrderViewModel order = new OrderViewModel()
            {
                BuyerId = user.Id,
                TotalPrice = totalPrice,
                TotalQuantity = 0,
                OrderNumber = orderNumber // Sipariş numarasını burada oluştur
            };
            await _orderService.CreateOrder(order);

            // Sipariş özeti için model
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

            // Ödeme işlemleri simüle edilmesi          

            bool paymentSuccess = SimulatePaymentProcess(model);

            if (paymentSuccess)
            {
                var user = await _accountService.Find(User.Identity.Name);
                var cart = await _cartService.GetCartByUserId(user.Id);
                decimal totalPrice = 0;
                int totalQuantity = 0;
                var cartItemList = await _cartService.GetAllCartItems(cart.Id);
                
                int number = 0;
                foreach (var item in cartItemList)
                {
                    number += item.Id;
                }
                var orderNumber = GenerateOrderNumber(cart.Id, number);
                var createdOrder = await _orderService.GetOrder(orderNumber);

                foreach (var item in cartItemList)
                {
                    
                    var product = await _productService.GetById(item.ProductId);
                    if (product.StockQuantity < item.Quantity)
                    {
                        TempData["ErrorMessage"] = "Ürün Satışta Değil!";
                        await _cartService.RemoveFromCartAsync(cart.Id, product.Id);
                        return RedirectToAction("Index", "Cart", cart);
                    }

                    totalQuantity += item.Quantity;
                    totalPrice += item.Price;

                    // Sipariş detayını oluştur
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

                    // Sipariş aktivitesini oluştur
                    decimal feePercentage = DetermineFeePercentage(orderDetail.UnitPrice);
                    decimal feeAmount = orderDetail.UnitPrice * feePercentage;
                    var seller = await _accountService.FindUserAsync(product.SellerId);
                    var orderActivity = new OrderActivityViewModel()
                    {
                        Activity = "Sipariş İşlemi",
                        OrderId = createdOrder.Id,
                        OrderNumber = createdOrder.OrderNumber,
                        BuyerId = user.Id,
                        BuyerName = user.Name,
                        BuyerSurname = user.Surname,
                        BuyerAddress = user.Address,
                        ProductId = product.Id,
                        ProductTitle = product.Title,
                        ProductImg = product.HeaderImageUrl,
                        SellerId = product.SellerId,
                        SellerName = seller.Name,
                        SellerSurname = seller.Surname,
                        TotalAmount = orderDetail.UnitPrice,
                        FeeAmount = feeAmount,
                        NetAmount = orderDetail.UnitPrice - feeAmount
                    };
                    await _orderService.CreateOrderActivity(orderActivity);

                    seller.Balance = orderActivity.NetAmount;
                    await _accountService.Update(seller);

                    // Ürünü güncelle
                    product.BuyerId = user.Id;
                    product.StockQuantity -= item.Quantity;
                    if (product.StockQuantity == 0)
                    {
                        product.IsSold = true;
                    }
                    await _productService.Update(product);

                }

                // Siparişi güncelle

                createdOrder.TotalQuantity = totalQuantity;                
                createdOrder.TotalPrice = totalPrice;
                await _orderService.UpdateOrder(createdOrder);

                

                // Sepeti temizle
                await _cartService.ClearCartAsync(cart.Id);

                return RedirectToAction("OrderConfirmation", new { orderId = createdOrder.Id });

            }



            return View();
        }

        public async Task<IActionResult> OrderConfirmation(int orderId)
        {
             
            var orderActivities = await _orderService.GetOrderActivityByOrderId(orderId);
            ViewBag.Order = await _orderService.GetOrderById(orderId);
            return View(orderActivities);
        }


        public async Task<ActionResult> ActivityDetail(int id)
        {
            var activity = await _orderService.GetOrderActivity(id);
            return View(activity);
        }




        //controllera özel methodlar

        private bool SimulatePaymentProcess(CheckoutViewModel model)
        {
            // Ödeme işleminin başarılı olduğunu varsayıyoruz.
            return true;
        }


        public string GenerateOrderNumber(int cartId,int number)
        {
            // Tarihi ve saati al
            var now = DateTime.Now;

            // Sipariş numarasını oluştur            
            string orderNumber = now.ToString("yyyyMMdd") + cartId.ToString() + number.ToString();

            return orderNumber;
        }

        private decimal DetermineFeePercentage(decimal unitPrice)
        {
            if (unitPrice <= 500) return 0.3m;
            if (unitPrice <= 2000) return 0.2m;
            if (unitPrice <= 8000) return 0.1m;
            return 0.05m; // 8000'den büyük için varsayılan değer
        }

    }

}
