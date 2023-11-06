using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.ViewModels
{
    public class WishlistItemViewModel
    {
        public int Id { get; set; }
        public int WishlistId { get; set; }
        public int ProductId { get; set; }
        public string ProductImg { get; set; }              
        public string Title { get; set; }       
        public decimal Price { get; set; }        
    }
}
