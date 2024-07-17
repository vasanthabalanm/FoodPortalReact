using FoodOrderDL.Models;

namespace FoodOrderBL.Interface
{
    public interface IPendingUser
    {
        Task<PendingUser> AddPendingUsers(PendingUser pendingUsers);
        Task<List<PendingUser>> GetOnlyPendingUserDetails();
        Task<string> DeletePendingUserDetails(int id);
        //Vendor
        Task<List<PendingUser>> GetOnlyPendingVendorDetails();
    }
}
