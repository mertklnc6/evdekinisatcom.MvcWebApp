using evdekinisatcom.MvcWebApp.Entity.Repositories;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.Services
{
    public interface ICartService
    {
        Task<CartViewModel> GetCartByUserId(int userId);

        Task<List<CartItemViewModel>> GetAllCartItems(int cartId);

        Task CreateCartAsync(CartViewModel model);

        Task CreateCartForUserAsync(int userId);        

        Task AddToCartAsync(CartItemViewModel model);

        Task ClearCartAsync(int cartId);

        Task RemoveFromCartAsync(int cartId, int productId);
        
    }
}
