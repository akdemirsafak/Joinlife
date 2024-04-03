using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Ticket.API.DbContexts;

namespace Ticket.API.Repository;

public class TicketRepository : ITicketRepository
{

    private readonly TicketDbContext _ticketDbContext;

    public TicketRepository(TicketDbContext ticketDbContext)
    {
        _ticketDbContext = ticketDbContext;
    }

    public async Task<Entity.Ticket> CreateAsync(Entity.Ticket ticket)
    {
        await _ticketDbContext.AddAsync(ticket);
        await _ticketDbContext.SaveChangesAsync();
        return ticket;
    }

    public async Task DeleteAsync(Entity.Ticket ticket)
    {
        _ticketDbContext.Remove(ticket);
        await _ticketDbContext.SaveChangesAsync();
    }

    public async Task<List<Entity.Ticket>> GetAllAsync()
    {
        return await _ticketDbContext.Tickets.ToListAsync();
    }

    public async Task<List<Entity.Ticket>> GetAsync(Expression<Func<Entity.Ticket, bool>>? filter = null)
    {
        return await _ticketDbContext.Tickets.Where(filter).ToListAsync();
    }

    public async Task<Entity.Ticket> GetByIdAsync(Guid id)
    {
        return await _ticketDbContext.Tickets.FindAsync(id);
    }

    public async Task<Entity.Ticket> UpdateAsync(Entity.Ticket entity)
    {
        _ticketDbContext.Tickets.Update(entity);
        await _ticketDbContext.SaveChangesAsync();
        return entity;
    }
}
