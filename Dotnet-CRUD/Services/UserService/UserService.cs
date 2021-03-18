using AutoMapper;
using Dotnet_CRUD.Dtos.User;
using Dotnet_CRUD.Models;
using Microsoft.AspNetCore.JsonPatch;
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
            new User{Id=1,Name="Nikola",LastName="Nikolic", Age=33},
            new User{Id=2, Name="Jovan", LastName="Mladic", Age=29}
        };


        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;

        }


        public async Task<List<GetUserDto>> AddUser(AddUserDto newUser) 
        {
            User user = _mapper.Map<User>(newUser);
            user.Id = users.Max(u => u.Id) + 1;
            users.Add(user);

            return users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
        }


        public async Task<List<GetUserDto>> DeleteUser(int id)
        {
            try
            {
                User user = users.First(user => user.Id == id);
                users.Remove(user);

            }catch(Exception err)
            {
                throw err;
            }
            return users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
        }

        public async Task<List<GetUserDto>> GetAllUsers(string search)
        {
            var quaryable = users.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                quaryable = quaryable.Where(user => user.Name.Contains(search) || user.LastName.Contains(search));
                return quaryable.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            }

             return users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
        }


        public async Task<GetUserDto> GetUserById(int id)
        {
            return _mapper.Map<GetUserDto>(users.FirstOrDefault(user => user.Id == id));
        }


        public async Task<User> PatchUser(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }



        public async Task<GetUserDto> UpdateUser(UpdateUserDto updatedUser)
        {
            User user = users.FirstOrDefault(user => user.Id == (updatedUser.Id));
            try
            {
                user.Name = updatedUser.Name;
                user.LastName = updatedUser.LastName;
                user.Age = updatedUser.Age;

            }catch(Exception err)
            {
                throw err;
            }

            return _mapper.Map<GetUserDto>(user);
        }
    }
}
