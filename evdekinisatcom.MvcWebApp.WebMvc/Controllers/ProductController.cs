﻿using AutoMapper;
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
        private readonly IUnitOfWork _uow;


        public ProductController(IMapper mapper, IProductService productService, IAccountService accountService, ICategoryService categoryService, ICommentService commentService, IUnitOfWork uow)
        {

            _mapper = mapper;
            _productService = productService;
            _accountService = accountService;
            _categoryService = categoryService;
            _commentService = commentService;
            _uow = uow;
        }

        public async Task<IActionResult> Index(string? id)
        {

            string oneCikanParametre = HttpContext.Request.Query["onecikan"];
            if (!string.IsNullOrEmpty(oneCikanParametre) && oneCikanParametre == "true")
            {
                //var list = new List<ProductViewModel>();
                var list = await _uow.GetRepository<Product>().GetAll(c => c.isBoosted == "Evet");

                return View(_mapper.Map<List<ProductViewModel>>(list));

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

            list = list.Where(a => a.Brand.ToLower().Contains(search.ToLower())).ToList();
            var allColor = list.Where(p => p.Color == selectedColor).ToList();
            return View(_mapper.Map<List<ProductViewModel>>(allColor));

        }

        [HttpPost]

        public async Task<IActionResult> Siralama(ProductViewModel model, string? search, string? sortOrder)
        {
            var list = await _productService.GetAll();

            if (search != null)
            {


                list = list.Where(a => a.Title.ToLower().Contains(search.ToLower())).ToList();
                return View("Index", _mapper.Map<List<ProductViewModel>>(list));

            }

            else
            {

                if (sortOrder == "asc")
                {
                    //list = await _uow.GetRepository<Product>().GetAll(orderby: query => query.OrderBy(p => p.Price));
                    //list = await _productService.GetAll(orderby: query => query.OrderBy(p => p.Price));
                    list = list.OrderBy(p => p.Price);
                    return View("Index", _mapper.Map<List<ProductViewModel>>(list));


                }
                if (sortOrder == "desc")
                {
                    //list = await _uow.GetRepository<Product>().GetAll(orderby: query => query.OrderByDescending(p => p.Price));
                    list = list.OrderByDescending(p => p.Price);
                    return View("Index", _mapper.Map<List<ProductViewModel>>(list));

                }
                return View("Index", _mapper.Map<List<ProductViewModel>>(list));

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

                var headerPath = Path.Combine(uploadPath, headerImage.FileName);
                var stream1 = new FileStream(headerPath, FileMode.Create);
                headerImage.CopyTo(stream1);

                model.HeaderImageUrl = "/userUploads/users/" + currentUser.Username + "/" + headerImage.FileName;

                List<string> imagePaths = new List<string>();
                foreach (var image in images)
                {


                    var imagePath = Path.Combine(uploadPath, image.FileName);
                    imagePaths.Add(imagePath);
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
            ViewBag.Comments = await _commentService.GetAllByProductId(id);
            ProductViewModel product = await _productService.GetById(id);
            return View(product);
        }

        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> CreateComment(int Id, string Message)
        {
            if(Message != null && Id != 0)
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
