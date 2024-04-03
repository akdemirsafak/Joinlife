using System.Linq.Expressions;
using Event.API.DbContexts;
using Event.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Event.API.Repositories;
public class EventRepository : IEventRepository
{
    private readonly EventyDbContext _eventyDbContext;

    public EventRepository(EventyDbContext eventyDbContext)
    {
        _eventyDbContext = eventyDbContext;
    }

    public async Task<Eventy> CreateAsync(Eventy eventy)
    {
        await _eventyDbContext.AddAsync(eventy);
        await _eventyDbContext.SaveChangesAsync();
        return eventy;
    }

    public async Task DeleteAsync(Eventy eventy)
    {
        _eventyDbContext.Events.Remove(eventy);
        await _eventyDbContext.SaveChangesAsync();
    }

    public async Task<List<Eventy>> GetAllAsync()
    {
        return await _eventyDbContext.Events.ToListAsync();
    }

    public async Task<Eventy> GetAsync(Expression<Func<Eventy, bool>>? filter = null)
    {
        return await _eventyDbContext.Events.SingleOrDefaultAsync(filter);
    }

    public async Task<Eventy> UpdateAsync(Eventy eventy)
    {
        _eventyDbContext.Events.Update(eventy);
        await _eventyDbContext.SaveChangesAsync();
        return eventy;
    }
}