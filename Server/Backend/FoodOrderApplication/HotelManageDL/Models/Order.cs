using System;
using System.Collections.Generic;

namespace HotelManageDL.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? ApprovedUsersId { get; set; }

    public int? HotelBranchId { get; set; }

    public int? MenuDetailsId { get; set; }

    public int? QuantityOfOrder { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? OrderStatus { get; set; }

    public virtual HotelBranch? HotelBranch { get; set; }

    public virtual MenuDetail? MenuDetails { get; set; }
}
