using AutoMapper;
using evdekinisatcom.MvcWebApp.Entity.Entities;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        

        public OrderService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            
        }

        public async Task CreateOrder(OrderViewModel model)
        {
            Order order = new Order();
            order = _mapper.Map<Order>(model);
            await _uow.GetRepository<Order>().Add(order);
            await _uow.CommitAsync();

        }

        public async Task CreateOrderDetail(OrderDetailViewModel model)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail = _mapper.Map<OrderDetail>(model);
            await _uow.GetRepository<OrderDetail>().Add(orderDetail);
            await _uow.CommitAsync();


        }

        public async Task<OrderViewModel> GetOrder(int id)
        {
            var order = await _uow.GetRepository<Order>().GetByIdAsync(o => o.BuyerId == id);
            return _mapper.Map<OrderViewModel>(order);
        }

        public async Task<List<OrderDetailViewModel>> GetAllOrderDetails(int id)
        {
            var orderDetails = await _uow.GetRepository<OrderDetail>().GetAll(o => o.OrderId == id);
            return _mapper.Map<List<OrderDetailViewModel>>(orderDetails);
        }

        public async Task UpdateOrder(OrderViewModel model)
        {
            var order = _mapper.Map<Order>(model);
            _uow.GetRepository<Order>().Update(order);
            await _uow.CommitAsync();


        }

        public async Task CreateOrderActivity(int orderId, string activity, int buyerId, int sellerId, decimal price)
        {

            var orderActivity = new OrderActivityViewModel()
            {
                OrderId = orderId,
                Activity = activity,
                BuyerId = buyerId,
                SellerId = sellerId,
                TotalPrice = price

            };

            var oActivity = _mapper.Map<OrderActivity>(orderActivity);
            await _uow.GetRepository<OrderActivity>().Add(oActivity);
            await _uow.CommitAsync();
        }

        public async Task<List<OrderActivityViewModel>> GetAllBuyerActivityByUserId(int id)
        {
            var list = await _uow.GetRepository<OrderActivity>().GetAll(o => o.BuyerId == id);            
            var activityList = _mapper.Map<List<OrderActivityViewModel>>(list);
            return activityList;
        }

        public async Task<List<OrderActivityViewModel>> GetAllSellerActivityByUserId(int id)
        {
            var list = await _uow.GetRepository<OrderActivity>().GetAll(o => o.SellerId == id);
            var activityList = _mapper.Map<List<OrderActivityViewModel>>(list);
            return activityList;
        }
    }
}
