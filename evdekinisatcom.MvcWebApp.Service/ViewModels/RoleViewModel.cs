using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Service.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Rol ismi mutlaka girilmelidir.")]
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
