using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace evdekinisatcom.MvcWebApp.Entity.ViewModels
{
    public class WithdrawViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Çekilecek Miktar")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Alıcı Adı Soyadı")]
        public string RecipientName { get; set; }

        [Required]
        [Display(Name = "IBAN")]        
        public string IBAN { get; set; }

        // Diğer gerekli alanlar eklenebilir.
    }

}
