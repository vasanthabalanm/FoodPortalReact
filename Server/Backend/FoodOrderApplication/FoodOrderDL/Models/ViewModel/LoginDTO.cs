using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderDL.Models.ViewModel
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public string TempPassword { get; set; } = string.Empty;
    }
}
