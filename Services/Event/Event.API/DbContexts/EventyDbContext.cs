using Event.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Event.API.DbContexts;

public sealed class EventyDbContext : DbContext
{
    public EventyDbContext(DbContextOptions<EventyDbContext> options) : base(options)
    {
    }
    public DbSet<Eventy> Events { get; set; }
    public DbSet<Tickety> Tickets { get; set; }
}