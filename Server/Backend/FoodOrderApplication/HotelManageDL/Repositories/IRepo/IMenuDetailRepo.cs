using HotelManageDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Repositories.IRepo
{
    public interface IMenuDetailRepo
    {
        Task<MenuDetail> AddMenu(MenuDetail menu);
        Task<List<MenuDetail>> GetMenuDetials();
        Task<MenuDetail> UpdateMenu(MenuDetail menu);
        Task<string> DeleteMenuDetails(int id, int hotelbranchId);
    }
}
