using HotelManageDL.MailHelper;
using HotelManageDL.Models;
using HotelManageDL.Repositories.IRepo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Repositories.ServiceRepo
{
    public class UserViewMenusRepo : IUserViewMenuRepo
    {
        private readonly HotelManagingApplicationContext _context;

        public UserViewMenusRepo(HotelManagingApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<UserViewMenuEntity>> GetMenuFromLocation(string menuName, string branchLocation)
        {
            var mname = new SqlParameter("@menuItems", menuName);
            var blocation = new SqlParameter("@branchLocation", branchLocation);
            var result = await _context.Set<UserViewMenuEntity>().FromSqlRaw("EXEC filterMenu @menuItems, @branchLocation", mname, blocation).ToListAsync();
            return result;
        }
        public async Task<List<PendingOrderEntity>> GetOrderDetails()
        {
            var result = await _context.Set<PendingOrderEntity>().FromSqlRaw("EXEC sendemail").ToListAsync();
            return result;
        }

        public async Task<PendingOrderEntity> StatusApproved(int orderId, string role)
         {
            var oId = new SqlParameter("@orderId", orderId);
            var rle = new SqlParameter("@userRole", role);
            
            var result = await _context.Set<PendingOrderEntity>().FromSqlRaw("EXEC ApporoveOrder @orderId,@userRole", oId,rle).ToListAsync();
            return result.FirstOrDefault();
        }
        
        public async Task<List<PendingOrderEntity>> UserViewApprovedMenuList(int id)
         {
            var userID = new SqlParameter("@userId", id);
            var result = await _context.Set<PendingOrderEntity>().FromSqlRaw("EXEC ApprovedUsersOrders @userId", userID).ToListAsync();
            return result;
        }
        public async Task<List<PendingOrderEntity>> UserViewPendingMenuList(int id)
         {
            var userID = new SqlParameter("@userId", id);
            var result = await _context.Set<PendingOrderEntity>().FromSqlRaw("EXEC UsersOrders @userId", userID).ToListAsync();
            return result;
        }

        public async Task<List<UserViewMenuEntity>> UserViewMenuList()
         {
            var allmenu = await _context.Set<UserViewMenuEntity>().FromSqlRaw("EXEC [dbo].[ShowMenuDetail]").ToListAsync();
            return allmenu;
        }

         
    }
}
