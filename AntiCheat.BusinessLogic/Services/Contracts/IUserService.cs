using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntiCheat.DataAccess.Models;

namespace AntiCheat.BusinessLogic.Services.Contracts
{
    interface IUserService
    {
        Task<List<User>> GetUsersAsync();

        Task<int> SaveUserAsync(User user);

        Task<Ticket> GetUserByIdAsync(int id);

        Task<int> SaveUserAsync(Ticket ticket);

        Task<int> DeleteUserAsync(int id);
    }
}
