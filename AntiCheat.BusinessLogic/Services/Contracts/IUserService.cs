using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntiCheat.DataAccess.Models;

namespace AntiCheat.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<int> SaveUserAsync(User user);

        Task<int> DeleteUserAsync(int id);
    }
}
