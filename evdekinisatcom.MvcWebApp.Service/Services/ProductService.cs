using AutoMapper;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;


        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task CreateAsync(ProductViewModel model)
        {

            Product product = new Product()
            {
                Title = model.Title,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Price = model.Price,
                Condition = model.Condition,
                SellerId = model.SellerId,
                Color = model.Color,
                CreatedDate = DateTime.Now,
                HeaderImageUrl = model.HeaderImageUrl,
                Images = model.Images
            };
            product = _mapper.Map<Product>(model);
            await _uow.GetRepository<Product>().Add(product);
            await _uow.CommitAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {

            var list = await _uow.GetRepository<Product>().GetAll(null, null, x => x.Images);


            return _mapper.Map<IEnumerable<ProductViewModel>>(list);


        }
        
        public async Task<IEnumerable<ProductViewModel>> GetAllOrderBy(Func<IQueryable<Product>, IOrderedQueryable<Product>> orderby)
        {

            var list = await _uow.GetRepository<Product>().GetAll(orderby: q => q.OrderByDescending(p => p.CreatedDate));


            return _mapper.Map<IEnumerable<ProductViewModel>>(list);


        }

        public async Task<IEnumerable<ProductViewModel>> GetAllByUserId(int id)
        {

            var list = await _uow.GetRepository<Product>().GetAll(p => p.SellerId == id);


            return _mapper.Map<IEnumerable<ProductViewModel>>(list);


        }
        public async Task<IEnumerable<ProductViewModel>> GetAllBoosted()
        {

            var list = await _uow.GetRepository<Product>().GetAll(p => p.IsBoosted == true);


            return _mapper.Map<IEnumerable<ProductViewModel>>(list);


        }


        public async Task Update(ProductViewModel model)
        {
            try
            {
                var product = await _uow.GetRepository<Product>().Get(p => p.Id == model.Id);
                if (model.Brand != null) { product.Brand = model.Brand; }
                if (model.Title != null) { product.Title = model.Title; }
                if (model.Description != null) { product.Description = model.Description; }
                if (model.Price != 0) { product.Price = model.Price; }
                if (model.CategoryId != 0) { product.CategoryId = model.CategoryId; }
                if (model.Color != null) { product.Color = model.Color; }
                if (model.HeaderImageUrl != null) { product.HeaderImageUrl = model.HeaderImageUrl; }
                if (model.Images != null) { product.Images = model.Images; }
                product.IsDeleted = model.IsDeleted;
                product.IsBoosted = model.IsBoosted;

                _uow.GetRepository<Product>().Update(product);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }


        }

        public async Task<ProductViewModel> GetByIdWithImages(int id)
        {
            var product = await _uow.GetRepository<Product>().GetByIdAsync(p => p.Id == id, null, p => p.Images);

            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            var product = await _uow.GetRepository<Product>().GetByIdAsync(p => p.Id == id);

            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<ProductViewModel> GetByUserId(int id)
        {
            var product = await _uow.GetRepository<Product>().GetByIdAsync(p => p.SellerId == id);

            return _mapper.Map<ProductViewModel>(product);
        }

    }
}
