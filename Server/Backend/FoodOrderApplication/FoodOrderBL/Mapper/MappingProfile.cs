using AutoMapper;
using FoodOrderDL.Models;
using FoodOrderDL.Models.ViewModel;

namespace FoodOrderBL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApprovedUserEntity, NewArrivalsDTO>().ReverseMap();
            CreateMap<ApprovedUser,LoginDTO>().ReverseMap();
        }
    }
}
