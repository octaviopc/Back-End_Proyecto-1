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

        public List<User> AddUser(User newUsers)
        {
            users.Add(newUsers);
            return users;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(c=>c.UserId ==id);
        }
    }
}