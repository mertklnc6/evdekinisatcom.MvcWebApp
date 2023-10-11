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


        public async Task Update(ProductViewModel model)
        {
            try
            {
                var product = _mapper.Map<Product>(model);
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

    }
}
