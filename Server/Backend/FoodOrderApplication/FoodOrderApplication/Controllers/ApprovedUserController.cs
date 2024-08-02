using FoodOrderApplication.ExceptionsHandler;
using FoodOrderBL.Interface;
using FoodOrderDL.Models;
using FoodOrderDL.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderApplication.Controllers
{
    [Route("api/[controller]")] //api/ApprovedUserController/
    [ApiController]
    public class ApprovedUserController : ControllerBase
    {
        private readonly IApprovedUser _approvedUser;

        public ApprovedUserController(IApprovedUser approvedUser)
        {
            _approvedUser = approvedUser;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetails()
        {
            var result = await _approvedUser.GetAllUserDetails();
            if (result.Count == 0)
            {
                throw new NotFoundExceptionHandler("There is No Record in UserTable");
            }
            return Ok(result);

        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> AddApprovedUser(ApprovedUser usersModel)
        {
            var result = await _approvedUser.AddApprovedUsers(usersModel);
            return Ok(result);
        }

        [HttpDelete("DeleteUserDetails")]
        public async Task<ActionResult> DeleteUsersDetails(int id)
        {
            var result = await _approvedUser.DeleteUserDetails(id);
            if (result == null)
            {
                throw new NotFoundExceptionHandler("There is no user");
            }
            return Ok(new
            {
                Status = 200,
                Message = "ApprovedUser has been deleted"
            });
        }

        [HttpGet("NewArrivals")]
        public async Task<IActionResult> GetNewArrivals()
        {
            var getUsers = await _approvedUser.GetNewArrivals();

            if (getUsers == null || getUsers.Count == 0)
            {
                throw new NotFoundExceptionHandler("There is no data found");
            }
            return Ok(getUsers);
        }

        [HttpGet("GetApprovedUser")]
        public async Task<IActionResult> GetApprovedUserData()
        {
            var result = await _approvedUser.GetOnlyUserDetails();
            if (result == null || result.Count == 0)
            {
                throw new NotFoundExceptionHandler("There is no Approved UserData");
            }
            return Ok(result);
        }

        [HttpGet("GetApprovedVendor")]
        public async Task<IActionResult> GetApprovedVendor()
        {
            var result = await _approvedUser.GetOnlyVendorDetails();
            if (result == null && result.Count == 0)
            {
                throw new NotFoundExceptionHandler("There is no Approved VendorData");
            }
            return Ok(result);
        }

        [HttpGet("TotalApprovedUser")]
        public async Task<IActionResult> CountApprovedUser()
        {
            var result = await _approvedUser.TotalapprovedUser();
            return Ok(result);
        }

        [HttpGet("TotalApprovedVendor")]
        public async Task<IActionResult> CountApprovedVendor()
        {
            var result = await _approvedUser.TotalapprovedVendor();
            return Ok(result);
        }

        [HttpGet("TotalPendingUser")]
        public async Task<IActionResult> CountPendingUser()
        {
            var result = await _approvedUser.TotalpendingUser();
            return Ok(result);
        }

        [HttpGet("TotalPendingVendor")]
        public async Task<IActionResult> CountPendingVendor()
        {
            var result = await _approvedUser.Totalpendingvendor();
            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUserDetails(int id,ApprovedUser user)
        {
            var result = await _approvedUser.UpdateUserDetails(id, user);
            if(result == null)
            {
                throw new NotFoundExceptionHandler("There is no Record in specific user id");
            }
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> GetUserInfoEmail(ApprovedUser data)
        {
            var result = await _approvedUser.GetUserInfoByEmail(data);
            if (result == null)
            {
                throw new NotFoundExceptionHandler("There is no Data by the specific Email ID");
            }
            return Ok(result);
        }

        [HttpPut("UpdatePassword")]
        public async Task<ActionResult> UpdatePassowrd([FromBody] ApprovedUser userdata)
        {
            var updatePass = await _approvedUser.UpdatePassword(userdata);
            if(updatePass == null)
            {
                throw new NotFoundExceptionHandler("There is no user Found and Changed");
            }
            return Ok(updatePass);
        }

        [HttpGet("GetMailbyId")]
        public async Task<ActionResult> GetMailbyId(int userId)
        {
            var result = await _approvedUser.GetMailById(userId);
            if(result == null)
            {
                throw new NotFoundExceptionHandler("There is no user Found by the specific Id");
            }
            return Ok(result);
        }
    }
}
