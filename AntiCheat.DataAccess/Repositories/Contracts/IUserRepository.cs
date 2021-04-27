using AntiCheat.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<int> SaveUserAsync(User user);

       
        Task<User> LoginAsync(string username, string password);
    }
}
