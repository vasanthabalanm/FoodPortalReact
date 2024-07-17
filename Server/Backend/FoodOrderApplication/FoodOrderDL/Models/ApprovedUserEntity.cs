using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderDL.Models
{
    public class ApprovedUserEntity
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserRole { get; set; }
        public string? Email { get; set; }
    }
}
