using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_End.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
            
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> Get()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<User>>> GetSingle(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<User>>>> AddUser(User newUser)
        {
            return Ok(await _userService.AddUser(newUser));
        }
    }
}