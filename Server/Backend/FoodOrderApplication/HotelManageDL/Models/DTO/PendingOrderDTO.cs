using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Models.DTO
{
    public class PendingOrderDTO
    {
        public int Id { get; set; }
        public int QuantityOfOrder { get; set; }
        public string OrderStatus { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public int? ApprovedUsersId { get; set; }
        public string MenuItems { get; set; } = string.Empty;
    }
}
