using AutoMapper;
using HotelManageBL.Interface;
using HotelManageDL.Models;
using HotelManageDL.Models.DTO;
using HotelManageDL.Repositories.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageBL.ServiceClass
{
    public class UserViewMenuService : IUserViewMenu
    {
        private readonly IUserViewMenuRepo _repo;
        private readonly IMapper _mapper;

        public UserViewMenuService(IUserViewMenuRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<UserMenuDTO>> GetMenuFromLocation(string menuName, string branchLocation)
        {
            var menuList = await _repo.GetMenuFromLocation(menuName, branchLocation);
            return _mapper.Map<List<UserMenuDTO>>(menuList);
        }

        public async Task<List<PendingOrderDTO>> GetOrderDetails()
        {
            var result =  await _repo.GetOrderDetails();
            return _mapper.Map<List<PendingOrderDTO>>(result);
        }

        public async Task<PendingOrderDTO> StatusApproved(int orderId, string role)
        {
            var result =  await _repo.StatusApproved(orderId, role);
            return _mapper.Map<PendingOrderDTO>(result);
        }

        public async Task<List<PendingOrderDTO>> UserViewApprovedMenuList(int id)
        {
            var result = await _repo.UserViewApprovedMenuList(id);
            return _mapper.Map<List<PendingOrderDTO>>(result);
        }

        public async Task<List<UserMenuDTO>> UserViewMenuList()
        {
            var result =  await _repo.UserViewMenuList();
            return _mapper.Map<List<UserMenuDTO>>(result);
        }

        public async Task<List<PendingOrderDTO>> UserViewPendingMenuList(int id)
        {
            var result = await _repo.UserViewPendingMenuList(id);
            return _mapper.Map<List<PendingOrderDTO>>(result);
        }
    }
}
