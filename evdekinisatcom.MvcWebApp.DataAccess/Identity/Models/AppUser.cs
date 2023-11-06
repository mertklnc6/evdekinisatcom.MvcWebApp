using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp.Entity.Entities;

namespace evdekinisatcom.MvcWebApp.DataAccess.Identity.Models
{
    public class AppUser : IdentityUser<int>
    {       
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Address { get; set; }

        public string ProfilePicUrl { get; set; }

        public decimal Balance { get; set; } = 0;

        public int? CartId { get; set; }        
        public int? WishlistId { get; set; }        

        //Navigation Property (Relation)

        public virtual Cart Cart { get; set; }
        public virtual Wishlist Wishlist { get; set; }


        

        public virtual List<Order> Orders { get; set; }
        public virtual List<Product> ProductsToSell { get; set; }
        public virtual List<Product> PurchasedProducts { get; set; }

        


    }
}
