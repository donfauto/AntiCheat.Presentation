using AntiCheat.BusinessLogic.Services.Contracts;
using AntiCheat.DataAccess.Models;
using AntiCheat.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.BusinessLogic.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public Task<int> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveUserAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
