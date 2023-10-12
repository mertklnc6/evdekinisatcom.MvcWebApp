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
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Çekilecek Miktar")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Alıcı Adı Soyadı")]
        public string RecipientName { get; set; }

        [Required]
        [Display(Name = "IBAN")]
        [RegularExpression(@"^TR\d{2}\s?(\w{4}\s?){4}\w{2}$", ErrorMessage = "Geçerli bir IBAN numarası girin.")]
        public string IBAN { get; set; }

        // Diğer gerekli alanlar eklenebilir.
    }

}
