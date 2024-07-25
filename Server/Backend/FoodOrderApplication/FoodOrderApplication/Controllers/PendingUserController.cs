using FoodOrderApplication.ExceptionsHandler;
using FoodOrderBL.Interface;
using FoodOrderDL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingUserController : ControllerBase
    {
        private readonly IPendingUser _pendingUser;

        public PendingUserController(IPendingUser pendingUser)
        {
            _pendingUser = pendingUser;
        }

        [HttpGet("GetPendingUser")]
        public async Task<IActionResult> GetAllUserDetails()
        {
            var result = await _pendingUser.GetOnlyPendingUserDetails();
            if (result == null || result.Count == 0)
            {
                throw new NotFoundExceptionHandler("There is no Data for Pending Users");
            }
            return Ok(result);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddPendingUser(PendingUser user)
        {
            var result = await _pendingUser.AddPendingUsers(user);
            return Ok(result);
        }

        [HttpDelete("DeletePendingUser")]
        public async Task<IActionResult> DeletePendingUser(int id)
        {
            var userId = await _pendingUser.DeletePendingUserDetails(id);
            if (userId == null)
            {
                throw new NotFoundExceptionHandler("There is no user");
            }
            return Ok(new
            {
                Status = 200,
                Message = "PendingUser has been deleted"
            });
        }

        //Vendor
        [HttpGet("GetPendingVendor")]
        public async Task<IActionResult> GetPendingVendor()
        {
            var result = await _pendingUser.GetOnlyPendingVendorDetails();
            if (result == null || result.Count == 0)
            {
                throw new NotFoundExceptionHandler("There is No Pending Vendor");
            }
            return Ok(result);
        }
    }
}
