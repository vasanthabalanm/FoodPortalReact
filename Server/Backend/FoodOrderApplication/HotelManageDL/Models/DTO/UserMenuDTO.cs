using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Models.DTO
{
    public class UserMenuDTO
    {
        public int Id { get; set; }
        public string MenuItems { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int HotelBranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string BranchLocation { get; set; } = string.Empty;
    }
}
