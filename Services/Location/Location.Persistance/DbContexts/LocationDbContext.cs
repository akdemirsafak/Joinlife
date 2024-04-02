using Location.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Location.Persistance.DbContexts;

public sealed class LocationDbContext : DbContext
{
    public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistanceAssemblyReference).Assembly);

        modelBuilder.Entity<City>().Navigation(x => x.Country).AutoInclude();
        modelBuilder.Entity<Country>().Navigation(x => x.Cities).AutoInclude();

        modelBuilder.Entity<City>().Navigation(x => x.Venues).AutoInclude();
        modelBuilder.Entity<Venue>().Navigation(x => x.City).AutoInclude();

        base.OnModelCreating(modelBuilder);
    }
}
