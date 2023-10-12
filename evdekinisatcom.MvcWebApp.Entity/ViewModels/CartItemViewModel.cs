using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductImg { get; set; }
        public string SellerUsername { get; set; }        
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; } = 0;
    }
}
