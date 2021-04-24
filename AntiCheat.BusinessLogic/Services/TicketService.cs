using AntiCheat.BusinessLogic.Services.Contracts;
using AntiCheat.DataAccess.Models;
using AntiCheat.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.BusinessLogic.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketSaleRepository _ticketSaleRepository;
        private readonly IBuyerRepository _buyerRepository;
        public TicketService(ITicketRepository ticketRepository, ITicketSaleRepository ticketSaleRepository, IBuyerRepository buyerRepository)
        {
            _ticketRepository = ticketRepository;
            _ticketSaleRepository = ticketSaleRepository;
            _buyerRepository = buyerRepository;
        }
        public async Task<int> DeleteTicketAsync(int id)
        {
            try
            {
                return await _ticketRepository.DeleteTicketAsync(id);

            }
            catch
            {
                throw;
            }
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            try
            {
                return await _ticketRepository.GetTicketByIdAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            try
            {
                return await _ticketRepository.GetTicketsAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> SaveTicketAsync(Ticket ticket)
        {
            try
            {
                return await _ticketRepository.SaveTicketAsync(ticket);
            }
            catch
            {
                throw;
            }
        }
    }
}
