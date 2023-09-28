using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using evdekinisatcom.MvcWebApp.DataAccess.Identity.Models;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using evdekinisatcom.MvcWebApp.Entity.Repositories;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp.Entity.Services;

namespace evdekinisatcom.MvcWebApp_App.WebMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAccountService _accountService;
		private readonly IMapper _mapper;        
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

		public ProductController(IMapper mapper, IProductService productService, IAccountService accountService, ICategoryService categoryService)
		{

			_mapper = mapper;
			_productService = productService;
			_accountService = accountService;
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
        {

            var list = await _productService.GetAll();
			return View(list);
		}

        [Authorize]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAll(), "Id", "Name","ParentCategoryId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(IFormFile headerImage, List<IFormFile> images)
        {

			//if (ModelState.IsValid)
			//{
			ProductViewModel model = new ProductViewModel();
			try
            {
                var currentUser = await _accountService.Find(User.Identity.Name);
                

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\userUploads\\users");
                var userPath = Path.Combine(uploadPath, currentUser.Username);
                uploadPath = userPath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var headerPath = Path.Combine(uploadPath, headerImage.FileName);
                var stream1 = new FileStream(headerPath, FileMode.Create);
                headerImage.CopyTo(stream1);

                model.HeaderImageUrl = "/userUploads/users/" + currentUser.Username + "/" + headerImage.FileName;

                List<string> imagePaths = new List<string>();
                foreach (var image in images)
                {


                    var imagePath = Path.Combine(uploadPath, image.FileName);
                    if (imagePath != null)
                    {
                        List<ProductImage> productImages = new List<ProductImage>();
                        foreach (var imageUrl in imagePaths)
                        {
                            productImages.Add(new ProductImage { ImageUrl = imageUrl });
                        }
                        model.Images = productImages;
                    }
                    else
                    {
                        var stream = new FileStream(imagePath, FileMode.Create);
                        await image.CopyToAsync(stream);

                        imagePaths.Add("/userUploads/users/" + currentUser.Username + "/" + image.FileName);
                        List<ProductImage> productImages = new List<ProductImage>();
                        foreach (var imageUrl in imagePaths)
                        {
                            productImages.Add(new ProductImage { ImageUrl = imageUrl });
                        }
                        model.Images = productImages;

                    }

                }

                

               await _productService.CreateAsync(model);                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Bir hata oluştu.");
            }
            //}

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            ProductViewModel product = await _productService.GetById(id);
            return View(product);
        }
    }
}
