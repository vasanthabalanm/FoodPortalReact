using HotelManageBL.Interface;
using HotelManageDL.Models;
using HotelManageOrders.ExceptionHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HotelManageOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBranchController : ControllerBase
    {
        private readonly IHotelBranch _branch;

        public HotelBranchController(IHotelBranch branch)
        {
            _branch = branch;
        }

        [HttpPost("AddBranch")]
        public async Task<ActionResult> AddBranch(HotelBranch hotelmodel)
        {
            try
            {

                var result = await _branch.AddBranch(hotelmodel);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("UpdateBranch")]
        public async Task<ActionResult> UpdateHotelDetails([FromBody] HotelBranch hotel)
        {
            var updateHotel = await _branch.UpdateHotel(hotel);
            if (updateHotel == null) 
            {
                throw new NotFoundExceptionHandler("There is no record of the specific id");
            }
            return Ok(updateHotel);

        }

        [HttpGet("DisplayBranch")]
        public async Task<ActionResult> GetHotelBranch()
        {
            var result = await _branch.GethotelDetials();
            if (result == null)
            {
                throw new NotFoundExceptionHandler("There is no record ");
            }
            return Ok(result);
        }

        //count
        [HttpGet("TotalBranchCounts")]
        public async Task<ActionResult<int>> GetAllBranch()
        {
            var result = await _branch.TotalapprovedBranchl();
            return Ok(result);
        }

        [HttpDelete("DeleteBranch")]
        public async Task<ActionResult> DeleteHotelBranch(int id, int hotelid)
        {
            var result = await _branch.DeleteHotelbranch(id, hotelid);

            if (result == null)
            {
                throw new NotFoundExceptionHandler("There is no data to Delete");
            }
            return Ok(new
            {
                Status = 200,
                Message = "HotelBranch has been deleted"
            });
        }
    }
}
