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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Eventy>().Navigation(e => e.Tickets).AutoInclude();
        modelBuilder.Entity<Eventy>().HasMany(e => e.Tickets).WithOne(t => t.Event).HasForeignKey(t => t.EventId);
        base.OnModelCreating(modelBuilder);
    }
}