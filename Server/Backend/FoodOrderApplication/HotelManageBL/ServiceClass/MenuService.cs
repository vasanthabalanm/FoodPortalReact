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
    public class MenuService : IMenu
    {
        private readonly IMenuDetailRepo _menurepo;

        public MenuService(IMenuDetailRepo menurepo)
        {
            _menurepo = menurepo;
        }

        public async Task<MenuDetail> AddMenu(MenuDetail menu)
        {
            return await _menurepo.AddMenu(menu);
        }

        public async Task<string> DeleteMenuDetails(int id, int hotelbranchId)
        {
            return await _menurepo.DeleteMenuDetails(id, hotelbranchId);
        }

        public async Task<List<MenuDetail>> GetMenuDetials()
        {
            return await _menurepo.GetMenuDetials();
        }

        public async Task<MenuDetail> UpdateMenu(MenuDetail menu)
        {
            return await _menurepo.UpdateMenu(menu);
        }
    }
}
