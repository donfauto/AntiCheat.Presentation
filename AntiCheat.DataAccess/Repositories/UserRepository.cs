using AntiCheat.DataAccess.DbContexts;
using AntiCheat.DataAccess.Models;
using AntiCheat.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AntiCheatDbContext _dbContext;

        public UserRepository(AntiCheatDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _dbContext.Users.Where(name => string.Equals(name.UserName, username) && string.Equals(name.Password, password)).FirstOrDefaultAsync();
            if (user != null)
                return user;

            throw new Exception("Usuario o Contraseña incorrecta");
        }

        public async Task<int> SaveUserAsync(User user)
        {
            await _dbContext.AddAsync(user);

            return await _dbContext.SaveChangesAsync();
        }
    }
}
