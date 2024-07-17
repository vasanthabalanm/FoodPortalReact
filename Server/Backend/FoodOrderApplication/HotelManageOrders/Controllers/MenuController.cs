using HotelManageBL.Interface;
using HotelManageDL.Models;
using HotelManageOrders.ExceptionHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManageOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenu _menu;

        public MenuController(IMenu menu)
        {
            _menu = menu;
        }

        [HttpPost("Addmenu")]
        public async Task<ActionResult> AddMenuItems(MenuDetail menumodel)
        {
            var result = await _menu.AddMenu(menumodel);
            return Ok(result);
        }

        [HttpGet("ViewMenu")]
        public async Task<ActionResult> GetMenuItems()
        {
            var result = await _menu.GetMenuDetials();
            if(result == null)
            {
                throw new NotFoundExceptionHandler("There is no data");
            }
            return Ok(result);
        }

        [HttpPut("updateMenu")]
        public async Task<ActionResult> UpdateMenuDetails([FromBody] MenuDetail menu)
        {
            var results = await _menu.UpdateMenu(menu);
            return Ok(results);
        }

        [HttpDelete("DeleteMenu")]
        public async Task<ActionResult> DeleteMenu(int id, int hotelbranchid)
        {
            var result = await _menu.DeleteMenuDetails(id, hotelbranchid);

            if (result == null)
            {
                throw new NotFoundExceptionHandler("There is no data to Delete");
            }
            return Ok(new
            {
                Status = 200,
                Message = "MenuItem has been deleted"
            });
        }
    }
}
