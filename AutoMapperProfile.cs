using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Back_End.Dtos.Inventory;
using Back_End.Dtos.User;

namespace Back_End
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<Inventory, GetInventoryDto>();
            CreateMap<AddInventoryDto, Inventory>();
        }

    }
}
