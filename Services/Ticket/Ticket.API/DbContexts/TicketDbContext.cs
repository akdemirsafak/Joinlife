using Microsoft.EntityFrameworkCore;

namespace Ticket.API.DbContexts
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
        {
        }
        public DbSet<Entity.Ticket> Tickets { get; set; }
    }
}
