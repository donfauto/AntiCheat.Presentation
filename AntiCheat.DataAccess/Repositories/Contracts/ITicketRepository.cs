using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiCheat.DataAccess.Models;

namespace AntiCheat.DataAccess.Repositories.Contracts
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(int id);


        Task<int> SaveTicketAsync(Ticket ticket);

        Task<int> DeleteTicketAsync(int id);


    }
}
