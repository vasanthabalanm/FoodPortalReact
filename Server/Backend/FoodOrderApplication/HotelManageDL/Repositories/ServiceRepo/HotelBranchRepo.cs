using HotelManageDL.Models;
using HotelManageDL.Repositories.IRepo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.Repositories.ServiceRepo
{
    public class HotelBranchRepo : IHotelBranchRepo
    {
        private readonly HotelManagingApplicationContext _context;

        public HotelBranchRepo(HotelManagingApplicationContext context)
        {
            _context = context;
        }

        public async Task<HotelBranch> AddBranch(HotelBranch branch)
        {
            if (await HotelBranchexistInHotel(branch.BranchName, branch.HotelId))
            {
                throw new InvalidOperationException(branch.BranchName + " already exists in this hotel.");
            }

            _context.Add(branch);
            await _context.SaveChangesAsync();
            return branch;
        }


        // already hotel in /DB or NOT
        private async Task<bool> HotelBranchexistInHotel(string? branchName, int? hotelId)
        {
            var result = await _context.HotelBranches.Where(x => x.BranchName == branchName && x.HotelId == hotelId).FirstOrDefaultAsync();
            if(result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<string> DeleteHotelbranch(int id, int hotelid)
        {
            var result = await _context.HotelBranches.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            if (hotelid == result.HotelId)
            {
                _context.HotelBranches.Remove(result);
                await _context.SaveChangesAsync();
                return "Delete successfully";
            }
            return null;
        }

        public async Task<List<HotelBranch>> GethotelDetials()
        {
            return await _context.HotelBranches.ToListAsync();
        }

        public async Task<HotelBranch> UpdateHotel(HotelBranch branch)
        {
            var result = await _context.HotelBranches.FindAsync(branch.Id);
            if (result == null)
            {
                return null;
            }
            if (branch.HotelId == result.HotelId)
            {
                result.BranchName = branch.BranchName;
                result.BranchLocation = branch.BranchLocation;
                result.BranchPhoneNumber = branch.BranchPhoneNumber;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<int> TotalapprovedBranchl()
        {
            return await _context.Hotels.CountAsync();
        }
    }
}
