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

        public UserService(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }
        public async Task<User> LoginAsync(string username, string password)
        {
            try
            {
                return await _userRepository.LoginAsync(username, password);
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
