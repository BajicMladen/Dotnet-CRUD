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
        Task<List<User>> GetAllUsers(string name);

        Task<User> GetUserById(int id);

        Task<List<User>> AddUser(User newUser);

        Task<User> UpdateUser(User updatedUser);

        Task<List<User>> DeleteUser(int id);

        Task<User> PatchUser(int id);



    }
}
