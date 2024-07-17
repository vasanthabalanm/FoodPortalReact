using HotelManageDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Repositories.IRepo
{
    public interface IHotelRepo
    {
        Task<Hotel> AddHotel(Hotel hotel);
        Task<List<Hotel>> GethotelDetials();
        Task<string> DeleteHotelDetails(int id, string role);
        Task<Hotel> UpdateHotel(Hotel hotel);

        //count
        Task<int> TotalapprovedHotel();
        
    }
}
