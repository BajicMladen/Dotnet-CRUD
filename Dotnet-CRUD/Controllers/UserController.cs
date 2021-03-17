using Dotnet_CRUD.Models;
using Dotnet_CRUD.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
    

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        public IActionResult addUser(User newUser)
        {
            
            return Ok(_userService.AddUser(newUser));
        }

        [HttpPut]
        public IActionResult updateUser(User updatedUser)
        {
            return Ok(_userService.UpdateUser(updatedUser));
        }

    }
}
