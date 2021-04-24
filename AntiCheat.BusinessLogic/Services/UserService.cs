using AntiCheat.BusinessLogic.Services.Contracts;
using AntiCheat.DataAccess.Models;
using AntiCheat.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<int> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await _userRepository.GetUsersAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> SaveUserAsync(User user)
        {
            try
            {
                return await _userRepository.SaveUserAsync(user);
            }
            catch
            {
                throw;
            }
        }
    }
}
