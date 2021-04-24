using AntiCheat.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<int> DeleteUserAsync(int id);
        Task<int> EditUserAsync(int id);
        Task<int> SaveUserAsync(User user );
    }
}
