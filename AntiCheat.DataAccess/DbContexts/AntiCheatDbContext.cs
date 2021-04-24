using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiCheat.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AntiCheat.DataAccess.DbContexts
{
    public class AntiCheatDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketSale> TicketSales { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<User> Users { get; set; }
        public AntiCheatDbContext(DbContextOptions<AntiCheatDbContext> options) : base(options)
        {

        }
    }
}
