using HotelManageBL.Interface;
using HotelManageDL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManageOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpPost("AddOrder")]
        public async Task<ActionResult> AddOrders(Order orders)
        {
            var result = await _order.AddOrders(orders);
            return Ok(result);
        }
    }
}
