using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using evdekinisatcom.MvcWebApp_App.WebMvc.Models;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;

namespace evdekinisatcom.MvcWebApp_App.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(ProductViewModel model, string? search)
        {

            var list = await _productService.GetAllBoosted();

            if (search != null)
            {
                list = await _productService.GetAll();
                list = list.Where(a => a.Title.ToLower().Contains(search.ToLower())).ToList();
            }

            return View(list);


        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Fees()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}