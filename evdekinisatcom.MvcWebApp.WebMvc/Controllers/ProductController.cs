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

namespace evdekinisatcom.MvcWebApp_App.WebMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;        
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IUnitOfWork _uow;

		public ProductController(IRepository<Category> categoryRepo, IMapper mapper, UserManager<AppUser> userManager,IUnitOfWork uow, IRepository<Product> productRepo)
		{
			_categoryRepo = categoryRepo;
            _mapper = mapper;
            _userManager = userManager;
            _uow = uow;
            _productRepo = productRepo;
           
		}

		public async Task<IActionResult> Index()
        {

			var products = await _productRepo.GetAllAsync();
			if (products != null)
			{
				return View(_mapper.Map<IEnumerable<ProductViewModel>>(products));
			}
			return View();
		}

        [Authorize]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryRepo.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ProductViewModel model, IFormFile headerImage, List<IFormFile> images)
        {

            //if (ModelState.IsValid)
            //{
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\userUploads\\users");
                var userPath = Path.Combine(uploadPath, currentUser.UserName);
                uploadPath = userPath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var headerPath = Path.Combine(uploadPath, headerImage.FileName);
                var stream1 = new FileStream(headerPath, FileMode.Create);
                headerImage.CopyTo(stream1);

                model.HeaderImageUrl = "/userUploads/users/" + currentUser.UserName + "/" + headerImage.FileName;

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

                        imagePaths.Add("/userUploads/users/" + currentUser.UserName + "/" + image.FileName);
                        List<ProductImage> productImages = new List<ProductImage>();
                        foreach (var imageUrl in imagePaths)
                        {
                            productImages.Add(new ProductImage { ImageUrl = imageUrl });
                        }
                        model.Images = productImages;

                    }

                }

                Product product = new Product()
                {
                    Title = model.Title,
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    Price = model.Price,
                    Condition = model.Condition,
                    SellerId = currentUser.Id,
                    CreatedDate = DateTime.Now,
                    HeaderImageUrl = model.HeaderImageUrl,
                    Images = model.Images
                };

                _productRepo.Add(product);
                _uow.GetRepository<Product>();
                _uow.Commit();
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
            Product product = await _productRepo.GetById(id); //Mapping olayları yapılacak
            return View(product);
        }
    }
}
