using System;
using System.Collections.Generic;

namespace HotelManageDL.Models;

public partial class MenuDetail
{
    public int Id { get; set; }

    public string? MenuItems { get; set; }

    public int? MenuQuantity { get; set; }

    public decimal? Price { get; set; }

    public int? HotelBranchId { get; set; }

    public virtual HotelBranch? HotelBranch { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
