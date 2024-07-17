using HotelManageDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Repositories.IRepo
{
    public interface IHotelBranchRepo
    {
        Task<HotelBranch> AddBranch(HotelBranch branch);
        Task<HotelBranch> UpdateHotel(HotelBranch branch);
        Task<List<HotelBranch>> GethotelDetials();
        Task<string> DeleteHotelbranch(int id, int hotelid);

        //count
        Task<int> TotalapprovedBranchl();
    }
}
