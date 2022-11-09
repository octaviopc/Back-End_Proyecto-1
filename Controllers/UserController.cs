using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User {UserId=0, Name="Tavo"},
            new User {UserId=1, Name="Daniel"}

            
        };

        [HttpGet("GetAll")]
        public ActionResult<List<User>> Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<List<User>> GetSingle(int id)
        {
            return Ok(users.FirstOrDefault(c=>c.UserId ==id));
        }
        
        [HttpPost]
        public ActionResult<List<User>> AddCharacter(User newUsers)
        {
            users.Add(newUsers);
            return Ok(users);
        }
    }
}