using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class WishlistItem : BaseEntity
    { 

        public string Title { get; set; }

        public decimal Price { get; set; }        

        public int WishlistId { get; set; }        

        public int ProductId { get; set; }
        public string ProductImg { get; set; }

        //Navigation Property
        public virtual Product Product { get; set; }
        public virtual Wishlist Wishlist { get; set; }

        

    }
}
