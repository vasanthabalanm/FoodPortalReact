using FoodOrderDL.Models;

namespace FoodOrderDL.Repositories.IRepo
{
    public interface IPendingUserRepo
    {
        // To manage User Roles
        Task<PendingUser> AddPendingUsers(PendingUser pendingUsers);
        Task<List<PendingUser>> GetOnlyPendingUserDetails();
        Task<string> DeletePendingUserDetails(int id);

        //To manage Vendor roles
        Task<List<PendingUser>> GetOnlyPendingVendorDetails();
        /*Task<PendingUser> AddPendingVendor(PendingUser pendingVendor);
        Task<string> DeletePendingVendorDetails(int id);*/
    }
}
