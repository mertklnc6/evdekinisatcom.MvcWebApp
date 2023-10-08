using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.Services
{
    public interface IOrderService
    {
        Task CreateOrder(OrderViewModel model);
        Task UpdateOrder(OrderViewModel model);
        Task<OrderViewModel> GetOrder(int userId);
        Task CreateOrderDetail(OrderDetailViewModel model);

        Task<List<OrderDetailViewModel>> GetAllOrderDetails(int id);

        Task CreateOrderActivity(int orderId, string activity, int buyerId, int sellerId, decimal price);

        Task<List<OrderActivityViewModel>> GetAllBuyerActivityByUserId(int id);
        Task<List<OrderActivityViewModel>> GetAllSellerActivityByUserId(int id);
    }
}
