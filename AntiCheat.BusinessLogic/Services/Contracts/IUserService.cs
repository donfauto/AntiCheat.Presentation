<<<<<<< HEAD
﻿using AntiCheat.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
=======
﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntiCheat.DataAccess.Models;
>>>>>>> 4b5e1739a7dd3ca991b39b3d449dad7240699266

namespace AntiCheat.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
<<<<<<< HEAD
        Task<int> SaveUserAsync(User user);


        Task<User> LoginAsync(string username, string password);
=======
        Task<List<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<int> SaveUserAsync(User user);

        Task<int> DeleteUserAsync(int id);
>>>>>>> 4b5e1739a7dd3ca991b39b3d449dad7240699266
    }
}
