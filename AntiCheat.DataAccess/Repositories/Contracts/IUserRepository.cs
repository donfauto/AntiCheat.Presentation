using AntiCheat.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
<<<<<<< HEAD
        Task<int> SaveUserAsync(User user);

       
        Task<User> LoginAsync(string username, string password);
=======
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<int> DeleteUserAsync(int id);
        Task<int> EditUserAsync(int id);
        Task<int> SaveUserAsync(User user );
>>>>>>> 4b5e1739a7dd3ca991b39b3d449dad7240699266
    }
}
