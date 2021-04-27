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
<<<<<<< HEAD
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
=======

        public async Task<int> DeleteUserAsync(int id)
        {
            var user = _dbContext.Users.Where(x => x.Id == id);
            if (user != null)
                _dbContext.Remove(user);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> EditUserAsync(int id)
        {
            var user = _dbContext.Users.Where(x => x.Id == id);
            if (user != null)
                _dbContext.Update(user);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var user = await _dbContext.Users.ToListAsync();
            return user;
        }

        public async Task<int> SaveUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            return await _dbContext.SaveChangesAsync();
        }

>>>>>>> 4b5e1739a7dd3ca991b39b3d449dad7240699266
    }
}
