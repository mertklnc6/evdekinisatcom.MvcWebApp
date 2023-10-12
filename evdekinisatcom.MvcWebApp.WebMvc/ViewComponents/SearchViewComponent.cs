using AutoMapper;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace evdekinisatcom.MvcWebApp.WebMvc.ViewComponents
{
    public class SearchViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public SearchViewComponent(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;

        }

        public async Task<IViewComponentResult> InvokeAsync(ProductViewModel model, string search)
        {

            var list = await _productService.GetAll();
            list = list.Where(a => a.Title.ToLower().Contains(search.ToLower())).ToList();
            return View(list);

        }
    }
}


