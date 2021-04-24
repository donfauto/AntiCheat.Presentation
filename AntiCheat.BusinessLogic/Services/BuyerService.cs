using AntiCheat.BusinessLogic.Services.Contracts;
using AntiCheat.DataAccess.Models;
using AntiCheat.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.BusinessLogic.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _buyerRepository;

        public BuyerService(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }
        public async Task<int> SaveTicketSaleAsync(Buyer buyer)
        {
            try
            {
                return await _buyerRepository.SaveTicketSaleAsync(buyer);
            }
            catch
            {
                throw;
            }
        }
    }
}
