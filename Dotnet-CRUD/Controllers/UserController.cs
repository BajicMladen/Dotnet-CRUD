using Dotnet_CRUD.Models;
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

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(users.FirstOrDefault(user => user.Id==id));
        }

    }
}
