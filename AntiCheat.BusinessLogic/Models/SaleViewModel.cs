using AntiCheat.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntiCheat.BusinessLogic.Models
{
    public class SaleViewModel
    {

        public Ticket Ticket { get; set; }
        public Buyer Buyer { get; set; }
        public TicketSale TicketSale { get; set; }
        public User User { get; set; }
    }
}
