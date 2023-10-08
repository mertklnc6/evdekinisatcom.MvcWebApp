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

        public int OrderId { get; set; }
        public string Activity { get; set; }
        public int BuyerId { get; set; }
        //public string BuyerUsername { get; set; }        
        public int SellerId { get; set; }
        //public string SellerUsername { get; set; }       
        public decimal TotalPrice { get; set; }
        public virtual Order Order { get; set; }

    }
}
