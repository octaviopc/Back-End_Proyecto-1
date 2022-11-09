using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Services.UserService
{
    public interface IUserService 
    {
        Task<ServiceResponse<List<User>>> GetAllUsers();
        Task<ServiceResponse<User>> GetUserById(int id);
        Task<ServiceResponse<List<User>>> AddUser(User newUsers);
        
    }
}