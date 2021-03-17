using Dotnet_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_CRUD.Services.UserService
{
   public interface IUserService
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        List<User> AddUser(User newUser);

    }
}
