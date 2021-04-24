using AntiCheat.DataAccess.Models;
using AntiCheat.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.DataAccess.Repositories.Contracts
{
    public interface ITicketSaleRepository
    {
        Task<int> SaveTicketSaleAsync(TicketSale ticketResponse, Buyer buyer, Ticket ticket);

        Task<bool> CheckIfTRansactionExistAsync(string numTransatransaction);
        Task<List<TicketResponse>> GetTicketsSalesAsync();

        Task<List<TicketResponse>> GetTicketsSalesByIdAsync(int id);
    }
}
