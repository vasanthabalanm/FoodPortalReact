using HotelManageDL.Models;
using HotelManageDL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageBL.Interface
{
    public interface IUserViewMenu
    {
        Task<List<UserMenuDTO>> GetMenuFromLocation(string menuName, string branchLocation);
        Task<List<UserMenuDTO>> UserViewMenuList();

        //show pending
        Task<List<PendingOrderDTO>> UserViewPendingMenuList(int id);
        //show approved
        Task<List<PendingOrderDTO>> UserViewApprovedMenuList(int id);

        //update in order table
        Task<PendingOrderDTO> StatusApproved(int orderId, string role);
        Task<List<PendingOrderDTO>> GetOrderDetails();
    }
}
