using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user.DTOs.User
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Role { get; set; } = "Member";
    }
}