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
    public class HotelService : IHotel
    {
        private readonly IHotelRepo _repo;

        public HotelService(IHotelRepo repo)
        {
            _repo = repo;
        }

        public async Task<Hotel> AddHotel(Hotel hotel)
        {
            return await _repo.AddHotel(hotel);
        }

        public async Task<string> DeleteHotelDetails(int id, string role)
        {
            return await _repo.DeleteHotelDetails(id, role);
        }

        public async Task<List<Hotel>> GethotelDetials()
        {
            return await _repo.GethotelDetials();
        }

        public async Task<int> TotalapprovedHotel()
        {
            return await _repo.TotalapprovedHotel();
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            var result = await _repo.UpdateHotel(hotel);
            return result;
        }
    }
}
