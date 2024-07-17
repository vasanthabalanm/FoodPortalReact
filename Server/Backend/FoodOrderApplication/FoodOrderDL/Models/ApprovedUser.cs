using System;
using System.Collections.Generic;

namespace FoodOrderDL.Models;

public partial class ApprovedUser
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? UserPassword { get; set; }

    public string? UserRole { get; set; }

    public string? UserPhone { get; set; }

    public string? UserLocation { get; set; }

    public string? TempPassword { get; set; }
}
