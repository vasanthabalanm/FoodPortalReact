using System;
using System.Collections.Generic;

namespace HotelManageDL.Models;

public partial class HotelBranch
{
    public int Id { get; set; }

    public string? BranchName { get; set; }

    public string? BranchLocation { get; set; }

    public string? BranchPhoneNumber { get; set; }

    public int? HotelId { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<MenuDetail> MenuDetails { get; set; } = new List<MenuDetail>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
