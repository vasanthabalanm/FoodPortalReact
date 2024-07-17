using HotelManageDL.Models;
using HotelManageDL.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Repositories.ServiceRepo
{
    public class MenuDetailRepo : IMenuDetailRepo
    {
        private readonly HotelManagingApplicationContext _context;

        public MenuDetailRepo(HotelManagingApplicationContext context)
        {
            _context = context;
        }

        public async Task<MenuDetail> AddMenu(MenuDetail menu)
        {
            if (await MenuExistsInHotelBranch(menu.MenuItems, menu.HotelBranchId))
            {
                throw new InvalidOperationException(menu.MenuItems + " already exists in this hotel.");
            }

            _context.Add(menu);
            await _context.SaveChangesAsync();
            return menu;
        }

        // already hotel in /DB or NOT
        private async Task<bool> MenuExistsInHotelBranch(string? menuName, int? hotelBranchId)
        {
            var result = await _context.MenuDetails.Where(x => x.MenuItems == menuName && x.HotelBranchId == hotelBranchId).FirstOrDefaultAsync();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<string> DeleteMenuDetails(int id, int hotelbranchId)
        {
            var result = await _context.MenuDetails.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            if (result.HotelBranchId == hotelbranchId)
            {
                _context.MenuDetails.Remove(result);
                await _context.SaveChangesAsync();
                return "Delete successfully";
            }
            return null;
        }

        public async Task<List<MenuDetail>> GetMenuDetials()
        {
            return await _context.MenuDetails.ToListAsync();
        }

        public async Task<MenuDetail> UpdateMenu(MenuDetail menu)
        {
            var result = await _context.MenuDetails.FindAsync(menu.Id);
            if (result == null)
            {
                return null;
            }
            if (menu.HotelBranchId == result.HotelBranchId)
            {
                result.MenuItems = menu.MenuItems;
                result.MenuQuantity = menu.MenuQuantity;
                result.Price = menu.Price;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
