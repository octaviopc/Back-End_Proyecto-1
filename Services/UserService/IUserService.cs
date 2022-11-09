using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Services.UserService
{
    public interface IUserService 
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<List<User>> AddUser(User newUsers);
        
    }
}