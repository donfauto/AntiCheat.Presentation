using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCheat.DataAccess.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public string BuyerLastName { get; set; }
        public int BuyerIdentification { get; set; }
        public int Phone { get; set; }
        public int AcountNumber { get; set; }


        public List<TicketSale> TicketSales { get; set; }

    }
}
