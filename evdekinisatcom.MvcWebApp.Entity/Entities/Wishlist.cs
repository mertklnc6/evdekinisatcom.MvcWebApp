using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.Entities
{
    public class Wishlist : BaseEntity
    {        
        public int UserId { get; set; }        

        public virtual ICollection<WishlistItem> WishlistItems { get; set; }
    }
}
