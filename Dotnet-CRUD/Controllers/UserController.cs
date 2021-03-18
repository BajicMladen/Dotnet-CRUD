using Dotnet_CRUD.Models;
using Dotnet_CRUD.Services.UserService;
using Microsoft.AspNetCore.Cors;
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

    

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [EnableCors]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string search)
        {
            return Ok(await _userService.GetAllUsers(search));
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User newUser)
        {
            
            return Ok(await _userService.AddUser(newUser));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User updatedUser)
        {
            return Ok(await _userService.UpdateUser(updatedUser));
        }

        [EnableCors]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok( await _userService.DeleteUser(id));
        }


        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PatchUser(int id, [FromBody] JsonPatchDocument<User> patchDoc)
        {                   
           
           patchDoc.ApplyTo( await _userService.PatchUser(id), ModelState);

            return Ok(await _userService.PatchUser(id));

        }

        [HttpOptions]
        public async Task<IActionResult> Option()
        {
            return NoContent();
        }


    }
}
