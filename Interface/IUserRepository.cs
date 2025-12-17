using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user.Models;

namespace user.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
    }
}