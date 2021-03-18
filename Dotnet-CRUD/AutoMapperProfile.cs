using AutoMapper;
using Dotnet_CRUD.Dtos.User;
using Dotnet_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_CRUD
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto,User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
