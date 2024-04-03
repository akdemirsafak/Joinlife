using System.Linq.Expressions;

namespace Ticket.API.Repository;

public interface ITicketRepository
{
    Task<List<Entity.Ticket>> GetAllAsync();
    Task<List<Entity.Ticket>> GetAsync(Expression<Func<Entity.Ticket, bool>>? filter = null);
    Task<Entity.Ticket> GetByIdAsync(Guid id);
    Task<Entity.Ticket> UpdateAsync(Entity.Ticket entity);
    Task DeleteAsync(Entity.Ticket ticket);
    Task<Entity.Ticket> CreateAsync(Entity.Ticket ticket);
}
