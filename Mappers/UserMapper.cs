using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user.DTOs.User;
using user.Models;

namespace user.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                CreatedOn = userModel.CreatedOn,
                Role = userModel.Role
            };
        }
        public static User ToUserFromCreateDto(this CreateUserDto userDto)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Role = userDto.Role
            };
        }
    }
}