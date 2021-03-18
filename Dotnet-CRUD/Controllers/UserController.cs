using Dotnet_CRUD.Models;
using Dotnet_CRUD.Services.UserService;
using Microsoft.AspNetCore.JsonPatch;
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

        private static List<User> users = new List<User>
        {
            new User{},
            new User {Id=1,Name="Nikola",LastName="Nikolic", age=33}
        };

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string search)
        {
            return Ok(_userService.GetAllUsers(search));
        }



        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        public IActionResult AddUser(User newUser)
        {
            
            return Ok(_userService.AddUser(newUser));
        }

        [HttpPut]
        public IActionResult UpdateUser(User updatedUser)
        {
            return Ok(_userService.UpdateUser(updatedUser));
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_userService.DeleteUser(id));
        }


        [HttpPatch("{id:int}")]
        public IActionResult PatchUser(int id, [FromBody] JsonPatchDocument<User> patchDoc)
        {                   
           
            patchDoc.ApplyTo(_userService.PatchUser(id), ModelState);

            return Ok(_userService.PatchUser(id));

        }


    }
}
