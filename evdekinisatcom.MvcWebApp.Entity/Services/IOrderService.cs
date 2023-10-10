﻿using evdekinisatcom.MvcWebApp.Entity.ViewModels;
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
        Task UpdateOrder(int orderId);
        Task<OrderViewModel> GetOrder(string orderNumber);
        Task CreateOrderDetail(OrderDetailViewModel model);

        Task<List<OrderDetailViewModel>> GetAllOrderDetails(int id);

        Task CreateOrderActivity(OrderActivityViewModel model);

        Task<List<OrderActivityViewModel>> GetAllBuyerActivityByUserId(int id);
        Task<List<OrderActivityViewModel>> GetOrderActivityByOrderId(int id);
        Task<List<OrderActivityViewModel>> GetAllSellerActivityByUserId(int id);
    }
}
