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
<<<<<<< HEAD

        public UserService(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }
        public async Task<User> LoginAsync(string username, string password)
        {
            try
            {
                return await _userRepository.LoginAsync(username, password);
=======
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
>>>>>>> 4b5e1739a7dd3ca991b39b3d449dad7240699266
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
