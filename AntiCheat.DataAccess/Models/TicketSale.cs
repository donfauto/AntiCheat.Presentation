using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.DataAccess.Models
{
    public class TicketSale
    {

        public int Id { get; set; }

        public string NumTransaction { get; set; }
        public string Country { get; set; }

        public int BuyerId { get; set; }

        public int UserId { get; set; }

        public Buyer Buyer { get; set; }

        public User User { get; set; }

        public List<Ticket> Ticket { get; set; }







    }
}
