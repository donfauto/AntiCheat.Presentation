using AntiCheat.DataAccess.DbContexts;
using AntiCheat.DataAccess.Models;
using AntiCheat.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.DataAccess.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly AntiCheatDbContext _dbContext;

        public BuyerRepository(AntiCheatDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> SaveTicketSaleAsync(Buyer buyer)
        {
            if (buyer.Id < 0)
                await _dbContext.Buyers.AddAsync(buyer);

            return await _dbContext.SaveChangesAsync();
        }
    }
}
