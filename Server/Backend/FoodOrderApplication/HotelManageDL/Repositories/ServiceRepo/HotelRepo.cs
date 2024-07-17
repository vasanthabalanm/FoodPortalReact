using Azure.Core;
using HotelManageDL.Models;
using HotelManageDL.Repositories.IRepo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HotelManageDL.Repositories.ServiceRepo
{
    public class HotelRepo : IHotelRepo
    {
        private readonly HotelManagingApplicationContext _context;

        public HotelRepo(HotelManagingApplicationContext context)
        {
            _context = context;
        }

        public async Task<Hotel> AddHotel(Hotel hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<List<Hotel>> GethotelDetials()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<string> DeleteHotelDetails(int id, string role)
        {
            var result = await _context.Hotels.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            if(role == "Admin")
            {
                _context.Hotels.Remove(result);
                await _context.SaveChangesAsync();
                return "Delete successfully";
            }
            return null;
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            var result = await _context.Hotels.FindAsync(hotel.Id);
            if (result == null)
            {
                return null;
            }
            if(hotel.ApprovedUsersId == result.ApprovedUsersId)
            {
                result.HotelName = hotel.HotelName;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
            
        }

        public async Task<int> TotalapprovedHotel()
        {
            return await _context.Hotels.CountAsync();
        }
    }
}
