using AntiCheat.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.BusinessLogic.Services.Contracts
{
    public interface IBuyerService
    {
        Task<int> SaveTicketSaleAsync(Buyer buyer);
    }
}
