using AntiCheat.BusinessLogic.Models;
using AntiCheat.DataAccess.Models;
using AntiCheat.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.BusinessLogic.Services.Contracts
{
    public interface ITicketSaleService
    {
        Task<int> SaveTicketSaleAsync(SaleViewModel saleViewModel);
        Task <bool> CheckIfTRansactionExistAsync(string numTransatransaction);
    }
}
