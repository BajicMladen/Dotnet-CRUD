using Dotnet_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_CRUD.Services.UserService
{
    public class UserService : IUserService
    {

        private static List<User> users = new List<User>
        {
            new User{},
            new User {Id=1,Name="Nikola",LastName="Nikolic", age=33}
        };

        public List<User> AddUser(User newUser)
        {
            users.Add(newUser);
            return users;
        }

        public List<User> GetAllUsers()
        {
             return users;
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }
    }
}
