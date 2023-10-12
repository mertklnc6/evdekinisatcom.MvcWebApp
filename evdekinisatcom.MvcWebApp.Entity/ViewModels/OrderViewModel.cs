using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.ViewModels
{
    public class OrderViewModel
    {
        public string OrderNumber { get; set; }

        public DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        public int BuyerId { get; set; }        
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }        

    }
}
