using HotelManageDL.Models;
using HotelManageDL.Repositories.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Repositories.ServiceRepo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly HotelManagingApplicationContext _context;

        public OrderRepo(HotelManagingApplicationContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrders(Order Orders)
        {
            _context.Add(Orders);
            await _context.SaveChangesAsync();
            return Orders;
        }
    }
}
