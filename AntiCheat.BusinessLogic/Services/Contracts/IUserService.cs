using AntiCheat.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        Task<int> SaveUserAsync(User user);


        Task<User> LoginAsync(string username, string password);
    }
}
