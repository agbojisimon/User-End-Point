using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using user.Interface;
using user.Mappers;

namespace user.Controllers
{
    [Route("user/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            this._userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userRepo.GetAllAsync();

            var userDto = user.Select(u => u.ToUserDto());

            return Ok(userDto);
        }
    }
}