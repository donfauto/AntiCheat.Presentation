using AntiCheat.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.BusinessLogic.Services.Contracts
{
    public interface ITicketService
    {

        Task<List<Ticket>> GetTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(int id);


        Task<int> SaveTicketAsync(Ticket ticket);

        Task<int> DeleteTicketAsync(int id);
    }
}
