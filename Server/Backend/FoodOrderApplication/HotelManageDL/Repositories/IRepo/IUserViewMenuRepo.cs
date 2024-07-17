using HotelManageDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Repositories.IRepo
{
    public interface IUserViewMenuRepo
    {
        Task<List<UserViewMenuEntity>> GetMenuFromLocation(string menuName, string branchLocation);

        Task<List<UserViewMenuEntity>> UserViewMenuList();

        //show pending
        Task<List<PendingOrderEntity>> UserViewPendingMenuList(int id);
        //show approved
        Task<List<PendingOrderEntity>> UserViewApprovedMenuList(int id);

        //update in order table
        Task<PendingOrderEntity> StatusApproved(int orderId, string role);
        Task<List<PendingOrderEntity>> GetOrderDetails();
    }
}
