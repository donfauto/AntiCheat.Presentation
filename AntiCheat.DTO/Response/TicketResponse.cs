using System;
using System.Collections.Generic;
using System.Text;

namespace AntiCheat.DTO.Response
{
    public class TicketResponse
    {
        public int Id { get; set; }

        public string NumTransaction { get; set; }
        public string CountryTransaction { get; set; }

        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public int BuyerIdentification { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string NumTicked { get; set; }

    }
}
