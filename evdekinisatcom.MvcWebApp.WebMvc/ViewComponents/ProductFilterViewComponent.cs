using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace evdekinisatcom.MvcWebApp.WebMvc.ViewComponents
{
    public class ProductFilterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<ProductViewModel> products, string selectedColor, string selectedBrand)
        {
            // Filtreleme işlemleri burada yapılır.
            var filteredProducts = FilterProducts(products, selectedColor, selectedBrand);

           
            return View(filteredProducts);
        }

        private List<ProductViewModel> FilterProducts(List<ProductViewModel> products, string selectedColor, string selectedBrand)
        {
            var filteredProducts = products;

            if (!string.IsNullOrEmpty(selectedColor))
            {
                filteredProducts = filteredProducts.Where(p => p.Color == selectedColor).ToList();
            }

            if (!string.IsNullOrEmpty(selectedBrand))
            {
                filteredProducts = filteredProducts.Where(p => p.Brand == selectedBrand).ToList();
            }
            

            return filteredProducts;
        }
    }
}
