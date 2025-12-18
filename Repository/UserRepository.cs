using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using user.Data;
using user.DTOs.User;
using user.Interface;
using user.Models;

namespace user.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        public async Task<User> CreateAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (userModel == null)
            {
                return null;
            }
            _context.Users.Remove(userModel);

            await _context.SaveChangesAsync();

            return userModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Role = userDto.Role;

            await _context.SaveChangesAsync();

            return existingUser;
        }
    }
}