using Dotnet_CRUD.Dtos.User;
using Dotnet_CRUD.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_CRUD.Services.UserService
{
   public interface IUserService
    {
        Task<List<GetUserDto>> GetAllUsers(string name);

        Task<GetUserDto> GetUserById(int id);

        Task<List<GetUserDto>> AddUser(AddUserDto newUser);

        Task<GetUserDto> UpdateUser(UpdateUserDto updatedUser);

        Task<List<GetUserDto>> DeleteUser(int id);

        Task<User> PatchUser(int id);



    }
}
