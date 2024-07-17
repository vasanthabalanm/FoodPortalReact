using FoodOrderDL.Repositories.IRepo;
using FoodOrderDL.Models;
using Microsoft.EntityFrameworkCore;
using FoodOrderDL.Models.ViewModel;
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace FoodOrderDL.Repositories.IServiceRepo
{
    public class ApprovedUserRepo : IApprovedUserRepo
    {
        private readonly FoodOrderOwnerApplicationContext _context;

        public ApprovedUserRepo(FoodOrderOwnerApplicationContext context)
        {
            _context = context;
        }

        public async Task<ApprovedUser> AddApprovedUsers(ApprovedUser approvedUsers)
        {
            _context.Add(approvedUsers);
            await _context.SaveChangesAsync();
            return approvedUsers;
        }

        public async Task<string> DeleteUserDetails(int id)
        {
            var userId = await _context.ApprovedUsers.FindAsync(id);
            if(userId == null)
            {
                return null;
            }
            else
            {
                _context.ApprovedUsers.Remove(userId);
                await _context.SaveChangesAsync();
                return "Deleted Successfully";

            }
        }

        public async Task<List<ApprovedUser>> GetAllUserDetails()
        {
            return await _context.ApprovedUsers.ToListAsync();
        }

        public async Task<List<ApprovedUserEntity>> GetNewArrivals()
        {
            var newUser = await _context.Set<ApprovedUserEntity>().FromSqlRaw("EXEC [dbo].[GetNewArrivals]").ToListAsync();
            return newUser;
        }

        public async Task<List<ApprovedUser>> GetOnlyUserDetails()
        {
            var roleUser = await _context.ApprovedUsers.Where(user => user.UserRole == "User").ToListAsync();
            return roleUser;
        }

        public async Task<List<ApprovedUser>> GetOnlyVendorDetails()
        {
            var roleVendor = await _context.ApprovedUsers.Where(vendor => vendor.UserRole == "Vendor").ToListAsync();
            return roleVendor;
        }
        

        public async Task<int> TotalapprovedUser()
        {
            var countUser = await _context.ApprovedUsers.CountAsync(userRole => userRole.UserRole == "User");
            return countUser;
        }

        public async Task<int> TotalapprovedVendor()
        {
            return await _context.ApprovedUsers.CountAsync(userRole => userRole.UserRole == "Vendor");
        }

        public async Task<int> TotalpendingUser()
        {
            return await _context.PendingUsers.CountAsync(userRole => userRole.UserRole == "User");
        }

        public async Task<int> Totalpendingvendor()
        {
            return await _context.PendingUsers.CountAsync(userRole => userRole.UserRole == "Vendor");
        }

        public async Task<ApprovedUser> UpdateUserDetails(int id,ApprovedUser user)
        {
            var result = await _context.ApprovedUsers.FindAsync(id);
            if(result == null)
            {
                return null;
            }
            result.UserName = user.UserName;
            result.UserPhone = user.UserPhone;
            result.UserPassword = user.UserPassword;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<ApprovedUser> GetUserInfoByEmail(ApprovedUser email)
        {
            var result = await _context.ApprovedUsers.Where(userEmail => userEmail.Email == email.Email).FirstOrDefaultAsync();
            if(result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<ApprovedUser> UpdatePassword(ApprovedUser user)
        {
            var existingUser = await _context.ApprovedUsers.Where(exixtusr => exixtusr.Id == user.Id && exixtusr.Email == user.Email && exixtusr.TempPassword == user.TempPassword ).FirstOrDefaultAsync();
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Id = user.Id;
            existingUser.Email = user.Email;
            existingUser.UserPassword = user.UserPassword;
            existingUser.TempPassword = null;
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<ApprovedUser> GetMailById(int id)
        {
            return await _context.ApprovedUsers.FindAsync(id);
        }
    }
}
