using FoodOrderBL.Interface;
using FoodOrderDL.Models;
using FoodOrderDL.Repositories.IRepo;

namespace FoodOrderBL.ServiceClass
{
    public class PendingUserService : IPendingUser
    {
        private readonly IPendingUserRepo _repo;

        public PendingUserService(IPendingUserRepo repo)
        {
            _repo = repo;
        }   

        public async Task<PendingUser> AddPendingUsers(PendingUser pendingUsers)
        {
            return await _repo.AddPendingUsers(pendingUsers);
        }

        public async Task<List<PendingUser>> GetOnlyPendingUserDetails()
        {
            return await _repo.GetOnlyPendingUserDetails();
        }

        public async Task<string> DeletePendingUserDetails(int id)
        {
            var userId = await _repo.DeletePendingUserDetails(id);
            if(userId == null)
            {
                return null;
            }
            return "Pending User Deleted Succussfully";
        }

        public async Task<List<PendingUser>> GetOnlyPendingVendorDetails()
        {
            return await _repo.GetOnlyPendingVendorDetails();
        }
    }
}
