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
    public class HotelBranchService : IHotelBranch
    {
        private readonly IHotelBranchRepo _repo;

        public HotelBranchService(IHotelBranchRepo repo)
        {
            _repo = repo;
        }

        public async Task<HotelBranch> AddBranch(HotelBranch branch)
        {
            return await _repo.AddBranch(branch);
        }

        public async Task<string> DeleteHotelbranch(int id, int hotelid)
        {
            return await _repo.DeleteHotelbranch(id, hotelid);
        }

        public async Task<List<HotelBranch>> GethotelDetials()
        {
            return await _repo.GethotelDetials();
        }

        public async Task<int> TotalapprovedBranchl()
        {
            return await _repo.TotalapprovedBranchl();
        }

        public async Task<HotelBranch> UpdateHotel(HotelBranch branch)
        {
            return await _repo.UpdateHotel(branch);
        }
    }
}
