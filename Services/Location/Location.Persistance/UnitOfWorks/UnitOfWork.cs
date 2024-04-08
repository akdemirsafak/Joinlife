using Location.Persistance.DbContexts;

namespace Location.Persistance.UnitOfWorks;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly LocationDbContext _context;

    public UnitOfWork(LocationDbContext context)
    {
        _context = context;
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
