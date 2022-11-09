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
        public ActionResult<List<User>> Get()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<List<User>> GetSingle(int id)
        {
            return Ok(_userService.GetUserById(id));
        }
        
        [HttpPost]
        public ActionResult<List<User>> AddUser(User newUsers)
        {
            return Ok(_userService.AddUser);
        }
    }
}