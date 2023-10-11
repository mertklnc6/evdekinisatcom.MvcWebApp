using AutoMapper;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace evdekinisatcom.MvcWebApp.WebMvc.ViewComponents
{
    public class SiralamaViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IUnitOfWork _uow;
        public SiralamaViewComponent(IMapper mapper, IProductService productService, IUnitOfWork uow)
        {
            _mapper = mapper;
            _productService = productService;
            _uow = uow;
        }

    
        public async Task<IViewComponentResult> InvokeAsync(ProductViewModel model, bool showAll = true, int? startIndex = null)
        {
            var list = await _productService.GetAll();

            if (showAll)
            {
                // Ürünleri CreatedDate'e göre veritabanında sırala
                var sortedData = await _uow.GetRepository<Product>().GetAll(orderby: q => q.OrderByDescending(p => p.CreatedDate));
                // Yeni üründen eskiye doğru yapmak
                var enYeniUrunler = sortedData.Take(8).ToList();
                return View(_mapper.Map<List<ProductViewModel>>(enYeniUrunler));
            }
            else if (startIndex.HasValue)
            {
                // Veritabanından başlangıç indeksine göre ürünleri al
                var sortedData = await _uow.GetRepository<Product>().GetAll(orderby: q => q.OrderByDescending(p => p.CreatedDate));
                var enYeniUrunler = sortedData.Skip(startIndex.Value).Take(1).ToList();
                return View(_mapper.Map<List<ProductViewModel>>(enYeniUrunler));
            }
            else
            {
                // Default davranış: Sadece son 3 ürünü göster
                var sortedData = await _uow.GetRepository<Product>().GetAll(orderby: q => q.OrderByDescending(p => p.CreatedDate));
                var enYeniUrunler = sortedData.Take(3).ToList();
                return View(_mapper.Map<List<ProductViewModel>>(enYeniUrunler));
            }


        }
    }
}
