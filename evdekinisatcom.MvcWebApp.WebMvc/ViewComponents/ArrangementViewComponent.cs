using AutoMapper;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace evdekinisatcom.MvcWebApp.WebMvc.ViewComponents
{
    public class ArrangementViewComponent :ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;        
        public ArrangementViewComponent(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;            
        }


        public async Task<IViewComponentResult> InvokeAsync(ProductViewModel model, bool showAll = true, int? startIndex = null)
        {
            var list = await _productService.GetAll();

            if (showAll)
            {
                // Ürünleri CreatedDate'e göre veritabanında sırala
                var sortedData = await _productService.GetAllOrderBy(orderby: q => q.OrderByDescending(p => p.CreatedDate));
                // Yeni üründen eskiye doğru yapmak
                var enYeniUrunler = sortedData.Take(8).ToList();
                return View(_mapper.Map<List<ProductViewModel>>(enYeniUrunler));
            }
            else if (startIndex.HasValue)
            {
                // Veritabanından başlangıç indeksine göre ürünleri al
                var sortedData = await _productService.GetAllOrderBy(orderby: q => q.OrderByDescending(p => p.CreatedDate));
                var newest = sortedData.Skip(startIndex.Value).Take(1).ToList();
                return View(newest);
            }
            else
            {
                // Default davranış: Sadece son 3 ürünü göster
                var sortedData = await _productService.GetAllOrderBy(orderby: q => q.OrderByDescending(p => p.CreatedDate));
                var newest = sortedData.Take(3).ToList();
                return View(newest);
            }


        }
    }
}
