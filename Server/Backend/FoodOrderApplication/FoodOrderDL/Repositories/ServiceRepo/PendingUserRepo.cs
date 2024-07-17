using FoodOrderDL.Models;
using FoodOrderDL.Repositories.IRepo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodOwnerDAL.Repositories.IServiceRepo
{
    public class PendingUserRepo : IPendingUserRepo
    {
        private readonly FoodOrderOwnerApplicationContext _context;

        #region Constructor
        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="context"></param>
        public PendingUserRepo(FoodOrderOwnerApplicationContext context)
        {
            _context = context;
        }
        #endregion

        #region Add-Pending User Role
        /// <summary>
        /// To Add User/vendor Role in PendingUser Table
        /// </summary>
        /// <param name="pendingUsers"></param>
        /// <returns>The same added user</returns>
        public async Task<PendingUser> AddPendingUsers(PendingUser pendingUsers)
        {
            if (await EmailExistsInPendingUsers(pendingUsers.Email))
            {
                throw new InvalidOperationException("Email already exists");
            }

            if (await EmailExistsInApprovedUsers(pendingUsers.Email))
            {
                throw new InvalidOperationException("Email already exists");
            }
            _context.PendingUsers.Add(pendingUsers);
            await _context.SaveChangesAsync();
            return pendingUsers;
        }
        #endregion

        #region To get All pending user details
        /// <summary>
        /// To get All pending user details to approve by admin
        /// </summary>
        /// <returns></returns>
        public async Task<List<PendingUser>> GetOnlyPendingUserDetails()
        {
            var userRoles = await _context.PendingUsers.Where(userRole => userRole.UserRole == "User").ToListAsync();
            return userRoles;
        }
        #endregion

        #region To delete Pending User/vendor
        /// <summary>
        /// To delete Pending User/vendor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeletePendingUserDetails(int id)
        {
            var userId = await _context.PendingUsers.FindAsync(id);
            if (userId == null)
            {
                return null;
            }
            _context.PendingUsers.Remove(userId);
            await _context.SaveChangesAsync();
            return "Pending User Deleted Succussfully";

        }
        #endregion

        #region To get the Pending Vendor Details
        /// <summary>
        /// To get the Pending Vendor Details
        /// </summary>
        /// <returns></returns>
        public async Task<List<PendingUser>> GetOnlyPendingVendorDetails()
        {
            var userRoles = await _context.PendingUsers.Where(userRole => userRole.UserRole == "Vendor").ToListAsync();
            return userRoles;
        }
        #endregion

        private async Task<bool> EmailExistsInApprovedUsers(string email)
        {
            var result = await _context.ApprovedUsers.Where(user=> user.Email == email).ToListAsync();
            return result.Count > 0;
        }
        private async Task<bool> EmailExistsInPendingUsers(string email)
        {
            var result = await _context.PendingUsers.Where(user => user.Email == email).ToListAsync();
            return result.Count > 0;
        }
    }
}
