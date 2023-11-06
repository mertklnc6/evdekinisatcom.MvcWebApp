using evdekinisatcom.MvcWebApp.Entity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace evdekinisatcom.MvcWebApp.WebMvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly IAccountService _accountService;
        public HomeController(IOrderService orderService, IAccountService accountService)
        {
            _orderService = orderService;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
		{
            var activities = await _orderService.GetAllOrderActivites();

			return View(activities);
		}
		public async Task<IActionResult> UserList()
		{
			var users = await _accountService.GetAllUsersAsync();
			return View(users);
		}

		public async Task<IActionResult> UserDetails(string id)
		{
			var user = await _accountService.FindByIdAsync(id);
			var buyerActivity = await _orderService.GetAllBuyerActivityByUserId(user.Id);
			var sellerActivity = await _orderService.GetAllSellerActivityByUserId(user.Id);
            ViewBag.buyerActivity = new SelectList(buyerActivity);
            ViewBag.sellerActivity = new SelectList(sellerActivity);
            return View();
		}

        public async Task<IActionResult> UserBuyerActivity(int id)
        {
			
            var user = await _accountService.FindByIdAsync(id.ToString());
            var buyerActivity = await _orderService.GetAllBuyerActivityByUserId(user.Id);            
            //ViewBag.buyerActivity = new SelectList(buyerActivity);            
            return View(buyerActivity);
        }
        
        public async Task<IActionResult> UserSellerActivity(int id)
        {
			
            var user = await _accountService.FindByIdAsync(id.ToString());
            var sellerActivity = await _orderService.GetAllSellerActivityByUserId(user.Id);            
            //ViewBag.buyerActivity = new SelectList(buyerActivity);            
            return View(sellerActivity);
        }

    }
}
