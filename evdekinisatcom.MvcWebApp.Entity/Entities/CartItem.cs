using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class CartItem : BaseEntity
    {
        
        public int Quantity { get; set; }

        public string SellerUsername { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }        

        public int CartId { get; set; }        

        public int ProductId { get; set; }

        //Navigation Property
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }



    }
}
