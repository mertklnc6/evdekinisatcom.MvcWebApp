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
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp.Service.Services;
using System.Collections.Generic;

namespace evdekinisatcom.MvcWebApp_App.WebMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public ProductController(IMapper mapper, IProductService productService, IAccountService accountService, ICategoryService categoryService, ICommentService commentService)
        {

            _mapper = mapper;
            _productService = productService;
            _accountService = accountService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index(string? id)
        {
            string oneCikanParametre = HttpContext.Request.Query["onecikan"];
            if (!string.IsNullOrEmpty(oneCikanParametre) && oneCikanParametre == "true")
            {

                var list = await _productService.GetAllBoosted();

                return View(list);

            }

            if (id == null)
            {
                var list = await _productService.GetAll();
                return View(list);
            }
            else
            {
                var list = new List<ProductViewModel>();
                var products = await _productService.GetAll();
                var categories = await _categoryService.GetAll();
                foreach (var product in products)
                {
                    if (product.CategoryId.ToString() == id)
                    {
                        list.Add(product);

                    }
                }
                foreach (var category in categories)
                {
                    if (category.Id.ToString() == id && category.ParentCategoryId == 1)
                    {
                        foreach (var subCategory in categories)
                        {
                            if (subCategory.ParentCategoryId == category.Id)
                            {
                                foreach (var product in products)
                                {
                                    if (product.CategoryId == subCategory.Id)
                                    {
                                        list.Add(product);
                                    }
                                }
                            }
                        }

                    }
                }

                return View(list);

            }




        }

        [HttpPost]
        public async Task<IActionResult> Index(string selectedColor, string search)
        {

            var list = await _productService.GetAll();
            if (search != null)
            {
                list = list.Where(a => a.Brand.ToLower().Contains(search.ToLower())).ToList();
            }
                       

            if (selectedColor != null)
            {
                list = list.Where(p => p.Color == selectedColor).ToList();
            }
            
            return View(list);

        }

        [HttpPost]

        public async Task<IActionResult>Arrangement(ProductViewModel model, string? search, string? sortOrder)
        {
            var list = await _productService.GetAll();

            if (search != null)
            {


                list = list.Where(a => a.Title.ToLower().Contains(search.ToLower())).ToList();
                return View("Index", list);

            }

            else
            {

                if (sortOrder == "asc")
                {                    
                    list = list.OrderBy(p => p.Price);
                    return View("Index", list);


                }
                if (sortOrder == "desc")
                {
                    
                    list = list.OrderByDescending(p => p.Price);
                    return View("Index", list);

                }
                return View("Index", list);

            }
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {

            var categoryList = await _categoryService.GetAll();
            var subCategoryList = new List<CategoryViewModel>();
            foreach (var sCategory in categoryList)
            {

                if (sCategory.ParentCategoryId != 1)
                {
                    subCategoryList.Add(sCategory);

                };
            }
            ViewBag.Categories = new SelectList(subCategoryList, "Id", "Name");
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
                var currentUser = await _accountService.Find(User.Identity.Name);
                if (currentUser != null)
                {
                    model.SellerId = currentUser.Id;
                    model.SellerUsername = currentUser.Username;
                }

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\userUploads\\users");
                var userPath = Path.Combine(uploadPath, currentUser.Username);
                uploadPath = userPath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Header Image için
                string headerFileExtension = Path.GetExtension(headerImage.FileName);
                string uniqueHeaderFileName = $"{Guid.NewGuid()}{headerFileExtension}";
                var headerPath = Path.Combine(uploadPath, uniqueHeaderFileName);
                using (var stream1 = new FileStream(headerPath, FileMode.Create))
                {
                    await headerImage.CopyToAsync(stream1);
                }
                model.HeaderImageUrl = "/userUploads/users/" + currentUser.Username + "/" + uniqueHeaderFileName;

                List<string> imagePaths = new List<string>();

                // Diğer resimler için
                foreach (var image in images)
                {
                    string fileExtension = Path.GetExtension(image.FileName);
                    string uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                    var imagePath = Path.Combine(uploadPath, uniqueFileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    imagePaths.Add("/userUploads/users/" + currentUser.Username + "/" + uniqueFileName);
                }

                List<ProductImage> productImages = new List<ProductImage>();
                foreach (var imageUrl in imagePaths)
                {
                    productImages.Add(new ProductImage { ImageUrl = imageUrl });
                }
                model.Images = productImages;

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
            ViewBag.Comments = await _commentService.GetAllByProductId(id);
            ProductViewModel product = await _productService.GetByIdWithImages(id);
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            var categoryList = await _categoryService.GetAll();
            var subCategoryList = categoryList.Where(s => s.ParentCategoryId != 1).ToList();
            ViewBag.Categories = new SelectList(subCategoryList, "Id", "Name");

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, ProductViewModel model, IFormFile headerImage, List<IFormFile> newImages)
        {
            if (id != model.Id)
            {
                return NotFound();
            }


            try
            {
                var currentUser = await _accountService.Find(User.Identity.Name);
                if (currentUser != null)
                {
                    model.SellerId = currentUser.Id;
                    model.SellerUsername = currentUser.Username;
                }


                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\userUploads\\users", currentUser.Username);
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                if (headerImage != null)
                {
                    string headerFileExtension = Path.GetExtension(headerImage.FileName);
                    string uniqueHeaderFileName = $"{Guid.NewGuid()}{headerFileExtension}";
                    var headerPath = Path.Combine(uploadPath, uniqueHeaderFileName);
                    using (var stream = new FileStream(headerPath, FileMode.Create))
                    {
                        await headerImage.CopyToAsync(stream);
                    }
                    model.HeaderImageUrl = "/userUploads/users/" + currentUser.Username + "/" + uniqueHeaderFileName;
                }

                if (newImages != null && newImages.Count > 0)
                {
                    List<string> imagePaths = new List<string>();
                    foreach (var image in newImages)
                    {
                        string fileExtension = Path.GetExtension(image.FileName);
                        string uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                        var imagePath = Path.Combine(uploadPath, uniqueFileName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }
                        imagePaths.Add("/userUploads/users/" + currentUser.Username + "/" + uniqueFileName);
                    }

                    List<ProductImage> productImages = new List<ProductImage>();
                    foreach (var imageUrl in imagePaths)
                    {
                        productImages.Add(new ProductImage { ImageUrl = imageUrl });
                    }
                    model.Images = productImages;
                }

                await _productService.Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Bir hata oluştu.");
            }


            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> MyProducts(int id)
        {
            var products = await _productService.GetAllByUserId(id);
            return View(products);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetById(id);
            product.IsDeleted = true;
            await _productService.Update(product);
            return RedirectToAction("Index", "Account");
        }

        public async Task<IActionResult> Publish(int id)
        {
            var product = await _productService.GetById(id);
            product.IsDeleted = false;
            await _productService.Update(product);
            return RedirectToAction("Index", "Account");
        }




        [Authorize]
        public async Task<IActionResult> CreateComment(int Id, string Message)
        {
            if (Message != null && Id != 0)
            {
                var user = await _accountService.Find(User.Identity.Name);
                CommentViewModel model = new CommentViewModel()
                {
                    ProductId = Id,
                    Content = Message,
                    UserId = user.Id,
                    Username = user.Username,
                    UserProfilePic = user.ProfilePicUrl

                };
                await _commentService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }





        }
    }
}
