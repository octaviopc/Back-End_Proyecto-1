using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>
        {
            new User {UserId=0, Name="Tavo"},
            new User {UserId=1, Name="Daniel"}            
        };

        public async Task<ServiceResponse<List<User>>> AddUser(User newUsers)
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            users.Add(newUsers);
            serviceResponse.Data= users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<User>>> GetAllUsers()
        {

            return new ServiceResponse<List<User>>{Data = users};
        }

        public async Task<ServiceResponse<User>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<User>();
            var user = users.FirstOrDefault(c=>c.UserId ==id);
            serviceResponse.Data = user;
            return serviceResponse;
        }
    }
}