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
    public interface IWishlistService
    {
        Task<WishlistViewModel> GetWishlistByUserId(int userId);

        Task<List<WishlistItemViewModel>> GetAllWishlistItems(int wishlistId);

        Task CreateWishlistAsync(WishlistViewModel model);

        Task CreateWishlistForUserAsync(int userId);        

        Task AddToWishlistAsync(WishlistItemViewModel model);

        Task ClearWishlistAsync(int wishlistId);

        Task RemoveFromWishlistAsync(int wishlistId, int productId);
        
    }
}
