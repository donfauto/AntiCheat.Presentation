using AntiCheat.DataAccess.DbContexts;
using AntiCheat.DataAccess.Models;
using AntiCheat.DTO.Response;
using AntiCheat.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AntiCheat.DataAccess.Repositories
{
    public class TicketSaleRepository : ITicketSaleRepository
    {
        private readonly AntiCheatDbContext _dbContext;

        public TicketSaleRepository(AntiCheatDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TicketResponse>> GetTicketsSalesAsync()
        {
            return await _dbContext.TicketSales.Include(x => x.Buyer).Include(x => x.Ticket).Select(x => new TicketResponse()


            {
                Id = x.Id,
                BuyerId = x.BuyerId,
                BuyerName = x.Buyer.BuyerName,
                BuyerLastName = x.Buyer.BuyerLastName,
                BuyerIdentification = x.Buyer.BuyerIdentification,
                CountryTransaction = x.Country,
                NumTransaction = x.NumTransaction,
                NumTicked = x.NumTransaction,
                UserId = x.UserId,
                UserName = x.User.UserName,


            }).ToListAsync();
        }

        public async Task<List<TicketResponse>> GetTicketsSalesByIdAsync(int id)
        {
            return await _dbContext.TicketSales.Where(x => x.UserId == id).Include(x => x.Buyer).Include(x => x.Ticket).Select(x => new TicketResponse()

            {

                Id = x.Id,
                BuyerId = x.BuyerId,
                BuyerName = x.Buyer.BuyerName,
                BuyerLastName = x.Buyer.BuyerLastName,
                BuyerIdentification = x.Buyer.BuyerIdentification,
                CountryTransaction = x.Country,
                NumTransaction = x.NumTransaction,
                NumTicked = x.NumTransaction,
                UserId = x.UserId,
                UserName = x.User.UserName,

            }).ToListAsync();

        }
        public async Task<bool> CheckIfTRansactionExistAsync(string numTransaction)
        {
            var chekNum =  await _dbContext.TicketSales.Where(x => x.NumTransaction == numTransaction).FirstOrDefaultAsync();
            if (chekNum != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<int> SaveTicketSaleAsync(TicketSale ticketResponse, Buyer buyer, Ticket ticket)
        {
            await _dbContext.Buyers.AddAsync(buyer);

            ticketResponse.Buyer = buyer;
            ticketResponse.User = await _dbContext.Users.Where(x => x.Id == ticketResponse.UserId).FirstOrDefaultAsync();

            await _dbContext.TicketSales.AddAsync(ticketResponse);
            ticket.TicketSale = ticketResponse;
            await _dbContext.Tickets.AddAsync(ticket);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
