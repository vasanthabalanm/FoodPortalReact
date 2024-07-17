using AutoMapper;
using HotelManageDL.Models;
using HotelManageDL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageBL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewMenuEntity, UserMenuDTO>().ReverseMap();
            CreateMap<PendingOrderEntity, PendingOrderDTO>().ReverseMap();
        }

    }
}
