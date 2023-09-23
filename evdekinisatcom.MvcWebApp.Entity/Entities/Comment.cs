using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class Comment : BaseEntity
    {
        
        public string Content { get; set; }        

        public int UserId { get; set; }        

        public int ProducId { get; set; }
        //Navigation Property
        public virtual Product Product { get; set; }
    }
}
