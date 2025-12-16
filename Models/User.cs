using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Role { get; set; } = "Member";
    }
}