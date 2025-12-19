using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace user.DTOs.User
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Firstname must not be less than 3 characters")]
        [MaxLength(50, ErrorMessage = "Firstname must not be greater than 50 characters")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MinLength(3, ErrorMessage = "Lastname must not be less than 3 characters")]
        [MaxLength(50, ErrorMessage = "Lastname must not be greater than 50 characters")]
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Member";
    }
}