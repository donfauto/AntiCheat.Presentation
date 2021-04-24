using AntiCheat.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.DataAccess.Repositories.Contracts
{
    public interface IBuyerRepository
    {
        Task<int> SaveTicketSaleAsync(Buyer buyer);
    }
}
