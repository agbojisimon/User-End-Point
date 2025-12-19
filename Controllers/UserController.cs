using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using user.DTOs.User;
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepo.GetAllAsync();

            var userDto = user.Select(u => u.ToUserDto());

            return Ok(userDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepo.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userModel = userDto.ToUserFromCreateDto();

            await _userRepo.CreateAsync(userModel);

            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepo.UpdateAsync(id, userDto);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userModel = await _userRepo.DeleteAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}