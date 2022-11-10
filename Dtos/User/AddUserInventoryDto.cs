using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Dtos.User
{
    public class AddUserInventoryDto
    {
        public int UserId { get; set; }
        public int ItemID { get; set; }

    }
}