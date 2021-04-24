using AntiCheat.BusinessLogic.Models;
using AntiCheat.BusinessLogic.Services.Contracts;
using AntiCheat.DataAccess.Models;
using AntiCheat.DataAccess.Repositories.Contracts;
using AntiCheat.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.BusinessLogic.Services
{
    public class TicketSaleService : ITicketSaleService
    {
        private readonly ITicketSaleRepository _ticketSaleRepository;

        public TicketSaleService(ITicketSaleRepository ticketSaleRepository)
        {
            _ticketSaleRepository = ticketSaleRepository;
        }

        public async Task<bool> CheckIfTRansactionExistAsync(string numTransatransaction)
        {
            try
            {
                return await _ticketSaleRepository.CheckIfTRansactionExistAsync(numTransatransaction);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TicketResponse>> GetTicketsSalesAsync()
        {
            try
            {
                return await _ticketSaleRepository.GetTicketsSalesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TicketResponse>> GetTicketsSalesByIdAsync(int id)
        {
            try
            {
                return await _ticketSaleRepository.GetTicketsSalesByIdAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> SaveTicketSaleAsync(SaleViewModel saleViewModel)
        {
            try
            {
                var buyer = new Buyer()
                {
                    BuyerName = saleViewModel.Buyer.BuyerName,
                    BuyerLastName = saleViewModel.Buyer.BuyerLastName,
                    BuyerIdentification = saleViewModel.Buyer.BuyerIdentification,
                    Phone = saleViewModel.Buyer.Phone,
                    AcountNumber = saleViewModel.Buyer.AcountNumber,


                };

                var saleTicket = new TicketSale()
                {
                    NumTransaction = saleViewModel.TicketSale.NumTransaction,
                    Country = saleViewModel.TicketSale.Country,
                    UserId = 1



                };


                var ticket = new Ticket()
                {
                    NumTicked = saleViewModel.Ticket.NumTicked



                };


                return await _ticketSaleRepository.SaveTicketSaleAsync(saleTicket, buyer, ticket);
            }
            catch
            {
                throw;
            }
        }


    }
}
