using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.ViewModels
{
    public class WishlistViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<WishlistItem> WishlistItems { get; set; }
    }
}
