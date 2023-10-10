using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.Entities
{
    public class OrderActivity : BaseEntity
    {
        
        public string Activity { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerSurname { get; set; }
        public string BuyerAddress { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerSurname { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal FeeAmount { get; set; }
        public decimal NetAmount { get; set; }
        public virtual Order Order { get; set; }

    }
}
