using HotelManageDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Repositories.IRepo
{
    public interface IOrderRepo
    {
        Task<Order> AddOrders(Order Orders);
    }
}
