﻿using Dotnet_CRUD.Models;
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
            User user = newUser;
            user.Id = users.Max(user => user.Id) + 1;
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

        public User UpdateUser(User updatedUser)
        {
            User user = users.FirstOrDefault(user => user.Id == updatedUser.Id);
            try
            {
                user.Name = updatedUser.Name;
                user.LastName = updatedUser.LastName;
                user.age = updatedUser.age;

            }catch(Exception err)
            {
                throw err;
            }

            return user;
        }
    }
}
