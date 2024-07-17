using FoodOrderDL.Models;
using FoodOrderDL.Models.ViewModel;

namespace FoodOrderBL.Interface
{
    public interface IApprovedUser
    {
        Task<List<ApprovedUser>> GetAllUserDetails();
        Task<ApprovedUser> AddApprovedUsers(ApprovedUser approvedUsers);
        Task<string> DeleteUserDetails(int id);
        Task<List<NewArrivalsDTO>> GetNewArrivals();

        Task<List<ApprovedUser>> GetOnlyUserDetails();
        Task<List<ApprovedUser>> GetOnlyVendorDetails();
        Task<ApprovedUser> UpdateUserDetails(int id, ApprovedUser user);
        Task<LoginDTO> GetUserInfoByEmail(ApprovedUser email);

        //no of counts
        Task<int> TotalapprovedUser();
        Task<int> TotalapprovedVendor();
        Task<int> TotalpendingUser();
        Task<int> Totalpendingvendor();

        Task<ApprovedUser> UpdatePassword(ApprovedUser user);

        //getemail by id
        Task<string> GetMailById(int id);
    }
}
