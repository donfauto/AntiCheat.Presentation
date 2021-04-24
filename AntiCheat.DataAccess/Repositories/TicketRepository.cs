using AntiCheat.DataAccess.DbContexts;
using AntiCheat.DataAccess.Models;
using AntiCheat.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AntiCheat.DataAccess.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AntiCheatDbContext _dbContext;

        public TicketRepository(AntiCheatDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> DeleteTicketAsync(int id)
        {
            var ticket = _dbContext.Tickets.Where(x => x.TicketId == id);
            if (ticket != null)
                _dbContext.Remove(ticket);

            return await _dbContext.SaveChangesAsync();

        }
        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            var ticket = await _dbContext.Tickets.Where(x => x.TicketId == id).FirstOrDefaultAsync();
            return ticket;

        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            var ticket = await _dbContext.Tickets.ToListAsync();
            return ticket;
        }

        public async Task<int> SaveTicketAsync(Ticket ticket)
        {
            if (ticket.TicketId < 0)
                await _dbContext.AddAsync(ticket);

            return await _dbContext.SaveChangesAsync();
        }
    }
}
