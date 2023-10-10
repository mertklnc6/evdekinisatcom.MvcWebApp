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
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public CartService(IUnitOfWork uow, IMapper mapper, IProductService productService)
        {
            _uow = uow;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task CreateCartForUserAsync(int userId)
        {
            var cart = new Cart() { UserId = userId };
            await _uow.GetRepository<Cart>().Add(cart);
            await _uow.CommitAsync();
        }
        public async Task<CartViewModel> GetCartByUserId(int userId)
        {
            var cart = await _uow.GetRepository<Cart>().Get(c => c.UserId == userId);
            return _mapper.Map<CartViewModel>(cart);

        }
        public async Task CreateCartAsync(CartViewModel model)
        {
            var cart = _mapper.Map<Cart>(model);
            await _uow.GetRepository<Cart>().Add(cart);
            await _uow.CommitAsync();
        }


        public async Task AddToCartAsync(CartItemViewModel model)
        {

            var product = await _uow.GetRepository<Product>().Get(p => p.Id == model.ProductId);
            if (product == null)
            {
                throw new InvalidOperationException("Ürün bulunamadı.");
            }

            if (product.StockQuantity < model.Quantity)
            {
                throw new InvalidOperationException("Stokta yeterli miktarda ürün bulunmamaktadır.");
            }

            var cart = await _uow.GetRepository<Cart>().GetByIdAsync(c => c.Id == model.CartId);
            if (cart == null)
            {
                throw new InvalidOperationException("Sepet bulunamadı.");
            }

            
            var existingCartItem = await _uow.GetRepository<CartItem>().GetByIdAsync(c => c.CartId == cart.Id && c.ProductId == product.Id);
            if (existingCartItem != null)
            {
                // Eğer sepete eklenmek istenen miktar stok miktarını aşıyorsa
                if (existingCartItem.Quantity + model.Quantity > product.StockQuantity)
                {
                    throw new InvalidOperationException("Stokta yeterli miktarda ürün bulunmamaktadır.");
                }
                else
                {
                    existingCartItem.Quantity += model.Quantity;
                }
                
            }
            else
            {
                var cartItem = _mapper.Map<CartItem>(model);              
                await _uow.GetRepository<CartItem>().Add(cartItem);
                await _uow.CommitAsync();
            }

            
        } 


        public async Task RemoveFromCartAsync(int cartId, int productId)
        {
            var cartItems = await _uow.GetRepository<CartItem>().GetAll(c => c.CartId == cartId && c.ProductId == productId);

            if (cartItems != null)
            {
                foreach (var cartItem in cartItems)
                {
                     _uow.GetRepository<CartItem>().DeletePermanently(cartItem.Id);
                }

                await _uow.CommitAsync();
            }
        }

        public async Task ClearCartAsync(int cartId)
        {
            await _uow.GetRepository<Cart>().GetByIdAsync(c => c.Id == cartId);
            var cartItemList = await _uow.GetRepository<CartItem>().GetAll(c => c.CartId == cartId);
            foreach (var cartItem in cartItemList)
            {
                _uow.GetRepository<CartItem>().DeletePermanently(cartItem.Id);
                _uow.Commit();
            }
            await _uow.CommitAsync();
        }
        

        public async Task<List<CartItemViewModel>> GetAllCartItems(int cartId)
        {
            var cartDetails = await _uow.GetRepository<CartItem>().GetAll(c => c.CartId == cartId);
            return _mapper.Map<List<CartItemViewModel>>(cartDetails);   
        }
    }
}
