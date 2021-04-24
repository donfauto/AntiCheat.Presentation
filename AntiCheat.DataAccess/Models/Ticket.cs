using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.DataAccess.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public string NumTicked { get; set; }


        public int TicketSaleId { get; set; }

        public TicketSale TicketSale { get; set; }

    }
}
