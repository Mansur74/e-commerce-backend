using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Concretes;
using Entities.Dtos;

namespace Core.Utilities.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>().ForMember(u => u.Roles, opt => opt.MapFrom(u => u.Roles.Select(ur => ur.Role)));
            //CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<ShopDto, Shop>();
            CreateMap<Shop, ShopDto>();
        }
    }
}
