using AutoMapper;
using PIdentityJwt.DTOs;
using PIdentityJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIdentityJwt.Helpers
{
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<User, UserDto>();
                CreateMap<UserDto, User>();

                CreateMap<Role, RoleDto>();
                CreateMap<RoleDto, Role>();

                CreateMap<UsersInRoles, UsersInRoles>().ReverseMap();
                CreateMap<MenuMaster, MenuMasterDto>().ReverseMap();
                CreateMap<Submenu, SubmenuDto>().ReverseMap();

        }
    }
}
