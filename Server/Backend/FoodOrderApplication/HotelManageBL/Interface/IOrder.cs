using HotelManageDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageBL.Interface
{
    public interface IOrder
    {
        Task<Order> AddOrders(Order Orders);
    }
}
