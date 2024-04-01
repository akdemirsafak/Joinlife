using Joinlife.webui.Entities;
using Microsoft.EntityFrameworkCore;
namespace Joinlife.webui.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<City>().Navigation(x => x.Country).AutoInclude();
        modelBuilder.Entity<Country>().Navigation(x => x.Cities).AutoInclude();

        modelBuilder.Entity<Venue>().Navigation(x => x.City).AutoInclude();

        modelBuilder.Entity<Event>().Navigation(x => x.Organizer).AutoInclude();
        modelBuilder.Entity<Event>().Navigation(x => x.Venue).AutoInclude();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}