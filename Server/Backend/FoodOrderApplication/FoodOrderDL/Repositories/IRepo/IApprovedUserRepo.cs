using FoodOrderDL.Models;

namespace FoodOrderDL.Repositories.IRepo
{
    public interface IApprovedUserRepo
    {
        Task<List<ApprovedUser>> GetAllUserDetails();
        Task<ApprovedUser> AddApprovedUsers(ApprovedUser approvedUsers);
        Task<string> DeleteUserDetails(int id);
        Task<List<ApprovedUserEntity>> GetNewArrivals();
        Task<List<ApprovedUser>> GetOnlyUserDetails();
        Task<List<ApprovedUser>> GetOnlyVendorDetails();
        Task<ApprovedUser> UpdateUserDetails(int id,ApprovedUser user);

        Task<ApprovedUser> GetUserInfoByEmail(ApprovedUser email);

        //no of counts
        Task<int> TotalapprovedUser();
        Task<int> TotalapprovedVendor();
        Task<int> TotalpendingUser();
        Task<int> Totalpendingvendor();

        //updat pass
        Task<ApprovedUser> UpdatePassword(ApprovedUser user);
        //get mail by id
        Task<ApprovedUser> GetMailById(int id);

    }
}
