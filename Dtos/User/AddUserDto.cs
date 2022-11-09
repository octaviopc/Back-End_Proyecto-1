using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Dtos.User
{
    public class AddUserDto
    {
        public string Name { get; set; }=string.Empty;
        public UserType_enum UserType { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        
    }
}