using HotelManageBL.Interface;
using HotelManageDL.Models;
using HotelManageOrders.ExceptionHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManageOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotel _hotel;

        public HotelController(IHotel hotel)
        {
            _hotel = hotel;
        }

        [HttpPost("AddHotel")]
        public async Task<ActionResult> AddHotel(Hotel hotel)
        {
            try
            {
                var result = await _hotel.AddHotel(hotel);

                if (result == null)
                {
                    throw new NotFoundExceptionHandler("There is no data to add");
                }

                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("ViewHotel")]
        public async Task<ActionResult> GetAllHotels()
        {
            List<Hotel> hotelmodel = await _hotel.GethotelDetials();
            if (hotelmodel == null)
            {
                throw new NotFoundExceptionHandler("Thers is no approved Hotel is Found! please register and then check it.");

            }
            return Ok(hotelmodel);
        }

        //count
        [HttpGet("TotalHotelCounts")]
        public async Task<ActionResult<int>> GetTotalHotel()
        {
            var result = await _hotel.TotalapprovedHotel();
            return Ok(result);
        }

        [HttpDelete("DeleteHotelDetails")]
        public async Task<ActionResult> DeleteHotelDetails(int id, string role)
        {
            var result = await _hotel.DeleteHotelDetails(id, role);

            if (result == null)
            {
                throw new NotFoundExceptionHandler("There is no data to Delete");
            }
            return Ok(new
            {
                Status = 200,
                Message = "Hotel has been deleted"
            });
        }

        [HttpPut("HotelUpdate")]
        public async Task<ActionResult> AlterHotel([FromBody] Hotel hotelModel)
        {
            var updaethotel = await _hotel.UpdateHotel(hotelModel);
            if(updaethotel == null)
            {
                throw new NotFoundExceptionHandler("There is no data to Update");
            }
            return Ok(updaethotel);
        }
    }
}
