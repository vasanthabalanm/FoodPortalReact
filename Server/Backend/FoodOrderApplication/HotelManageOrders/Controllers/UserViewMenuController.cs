using HotelManageBL.Interface;
using HotelManageOrders.ExceptionHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManageOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserViewMenuController : ControllerBase
    {
        private readonly IUserViewMenu _viewmenu;

        public UserViewMenuController(IUserViewMenu viewmenu)
        {
            _viewmenu = viewmenu;
        }

        [HttpGet("FilterbyLocation")]
        public async Task<ActionResult> FilterByLocation(string menuName, string branchLocation)
        {
            var menu = await _viewmenu.GetMenuFromLocation(menuName, branchLocation);
            if (menu == null)
            {
                throw new NotFoundExceptionHandler("There is no data");
            }
            else
            {
                return Ok(menu);
            }
        }

        [HttpGet("UserViewMenu")]
        public async Task<ActionResult> UserViewMenuDetails()
        {
            var result = await _viewmenu.UserViewMenuList();
            if(result == null)
            {
                throw new NotFoundExceptionHandler("There is no data");
            }
            return Ok(result);
        }

        [HttpGet("UserViewPendingOrder")]
        public async Task<ActionResult> UserViewPendingOrderDetails(int id)
        {
            var result = await _viewmenu.UserViewPendingMenuList(id);
            if(result == null)
            {
                throw new NotFoundExceptionHandler("There is no pending order");
            }
            return Ok(result);
        }

        [HttpGet("UserViewApprovedOrder")]
        public async Task<ActionResult> UserViewApprovedOrderDetails(int id)
        {
            var result = await _viewmenu.UserViewApprovedMenuList(id);
            if (result == null)
            {
                throw new NotFoundExceptionHandler("There is no pending order");
            }
            return Ok(result);
        }

        [HttpPut("OrderStatusChange")]
        public async Task<ActionResult> OrderStatusChange(int orderid, string role)
        {
            var result = await _viewmenu.StatusApproved(orderid, role);
            if(result == null)
            {
                throw new Exception("No update happens");
            }
            return Ok(result);
        }

        [HttpGet("ViewOrders")]
        public async Task<ActionResult> GetOrderDetails()
        {
            var result = await _viewmenu.GetOrderDetails();
            return Ok(result);
        }
    }
}
