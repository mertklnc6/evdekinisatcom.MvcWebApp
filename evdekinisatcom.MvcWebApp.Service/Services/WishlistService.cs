using AutoMapper;
using evdekinisatcom.MvcWebApp.DataAccess.UnitOfWorks;
using evdekinisatcom.MvcWebApp.Entity.Entities;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Service.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public WishlistService(IUnitOfWork uow, IMapper mapper, IProductService productService)
        {
            _uow = uow;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task CreateWishlistForUserAsync(int userId)
        {
            var wishlist = new Wishlist() { UserId = userId };
            await _uow.GetRepository<Wishlist>().Add(wishlist);
            await _uow.CommitAsync();
        }
        public async Task<WishlistViewModel> GetWishlistByUserId(int userId)
        {
            var wishlist = await _uow.GetRepository<Wishlist>().Get(w => w.UserId == userId);
            return _mapper.Map<WishlistViewModel>(wishlist);

        }
        public async Task CreateWishlistAsync(WishlistViewModel model)
        {
            var wishlist = _mapper.Map<Wishlist>(model);
            await _uow.GetRepository<Wishlist>().Add(wishlist);
            await _uow.CommitAsync();
        }


        public async Task AddToWishlistAsync(WishlistItemViewModel model)
        {

            var product = await _uow.GetRepository<Product>().Get(p => p.Id == model.ProductId);
            if (product == null)
            {
                throw new InvalidOperationException("Ürün bulunamadı.");
            }
            

            var wishlist = await _uow.GetRepository<Wishlist>().GetByIdAsync(c => c.Id == model.WishlistId);
            if (wishlist == null)
            {
                throw new InvalidOperationException("İstek listesi bulunamadı.");
            }

            
            var existingWishlistItem = await _uow.GetRepository<WishlistItem>().GetByIdAsync(c => c.WishlistId == wishlist.Id && c.ProductId == product.Id);
            if (existingWishlistItem != null)
            {                
                
            }
            else
            {
                var wishlistItem = _mapper.Map<WishlistItem>(model);              
                await _uow.GetRepository<WishlistItem>().Add(wishlistItem);
                await _uow.CommitAsync();
            }

            
        } 


        public async Task RemoveFromWishlistAsync(int wishlistId, int productId)
        {
            var wishlistItems = await _uow.GetRepository<WishlistItem>().GetAll(c => c.WishlistId == wishlistId && c.ProductId == productId);

            if (wishlistItems != null)
            {
                foreach (var wishlistItem in wishlistItems)
                {
                     _uow.GetRepository<WishlistItem>().DeletePermanently(wishlistItem.Id);
                }

                await _uow.CommitAsync();
            }
        }

        public async Task ClearWishlistAsync(int WishlistId)
        {
            await _uow.GetRepository<Wishlist>().GetByIdAsync(c => c.Id == WishlistId);
            var wishlistItemList = await _uow.GetRepository<WishlistItem>().GetAll(c => c.WishlistId == WishlistId);
            foreach (var wishlistItem in wishlistItemList)
            {
                _uow.GetRepository<WishlistItem>().DeletePermanently(wishlistItem.Id);
                _uow.Commit();
            }
            await _uow.CommitAsync();
        }
        

        public async Task<List<WishlistItemViewModel>> GetAllWishlistItems(int wishlistId)
        {
            var wishlistDetails = await _uow.GetRepository<WishlistItem>().GetAll(c => c.WishlistId == wishlistId);
            return _mapper.Map<List<WishlistItemViewModel>>(wishlistDetails);   
        }
    }
}
