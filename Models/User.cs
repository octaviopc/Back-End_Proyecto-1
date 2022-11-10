using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//User Object Properties:
//User {UserId, Name, UserType(Enum), Email, Phone}
namespace Back_End.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public UserType_enum UserType { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<Inventory>? Inventories { get; set; }

    }
}