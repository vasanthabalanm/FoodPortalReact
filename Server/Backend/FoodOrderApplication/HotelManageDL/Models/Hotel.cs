namespace HotelManageDL.Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string? HotelName { get; set; }

    public int? ApprovedUsersId { get; set; }

    public virtual ICollection<HotelBranch> HotelBranches { get; set; } = new List<HotelBranch>();
}
