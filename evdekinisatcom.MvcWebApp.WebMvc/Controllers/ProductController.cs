using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using evdekinisatcom.MvcWebApp.DataAccess.Identity.Models;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Entity.Interfaces;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;

namespace evdekinisatcom.MvcWebApp_App.WebMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public ProductController(IRepository<Product> productRepo, IRepository<Category> categoryRepo, UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _productRepo = productRepo;
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            var products = _productRepo.GetAll();
            if (products != null)
            {
                return View(_mapper.Map<IEnumerable<ProductViewModel>>(products));
            }
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryRepo.GetAll(), "Id", "Name");
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
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\userUploads");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var headerPath = Path.Combine(uploadPath, headerImage.FileName);
                using (var stream1 = new FileStream(headerPath, FileMode.Create))
                {
                    headerImage.CopyTo(stream1);
                }
                model.HeaderImageUrl = "/userUploads/" + headerImage.FileName;

                List<string> imagePaths = new List<string>();
                foreach (var image in images)
                {
                    var imagePath = Path.Combine(uploadPath, image.FileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    imagePaths.Add("/userUploads/" + image.FileName);
                }

                List<ProductImage> productImages = new List<ProductImage>();
                foreach (var imageUrl in imagePaths)
                {
                    productImages.Add(new ProductImage { ImageUrl = imageUrl });
                }
                model.Images = productImages;

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
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Bir hata oluştu.");
            }
            //}

            return View(model);
        }

        public IActionResult Details(int id)
        {
            Product product = _productRepo.GetById(id); //Mapping olayları yapılacak
            return View(product);
        }
    }
}
