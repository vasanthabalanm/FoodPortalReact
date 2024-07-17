using HotelManageBL.Interface;
using HotelManageDL.Models;
using HotelManageDL.Repositories.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageBL.ServiceClass
{
    public class OrderService : IOrder
    {
        private readonly IOrderRepo _repo;

        public OrderService(IOrderRepo repo)
        {
            _repo = repo;
        }

        public async Task<Order> AddOrders(Order Orders)
        {
            return await _repo.AddOrders(Orders);
        }
    }
}
