using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.Entities
{
    public class Withdrawal : BaseEntity
    {
        
        public string UserId { get; set; }        
        public decimal Amount { get; set; }
        public string IBAN { get; set; }
        public string RecipientName { get; set; }
        
    }

}
