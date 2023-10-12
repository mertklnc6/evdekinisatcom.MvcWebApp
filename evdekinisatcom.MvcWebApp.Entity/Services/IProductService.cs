using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<IEnumerable<ProductViewModel>> GetAllByUserId(int id);

        Task<ProductViewModel> GetByUserId(int id);

        Task<ProductViewModel> GetByIdWithImages(int id);       
        Task CreateAsync(ProductViewModel model);

        Task Update(ProductViewModel model);

        Task<ProductViewModel> GetById(int id);
    }
}
