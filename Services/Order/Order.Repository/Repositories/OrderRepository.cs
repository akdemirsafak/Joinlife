using Microsoft.EntityFrameworkCore;
using Order.Domain.Repositories;
using Order.Repository.DbContexts;
using System.Linq.Expressions;

namespace Order.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entity.Order> CreateAsync(Domain.Entity.Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Domain.Entity.Order>> GetAllAsync()
        {
            return await _context.Orders.Include(x => x.OrderItems).ToListAsync();
        }

        public async Task<Domain.Entity.Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders.Include(x => x.OrderItems).SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Domain.Entity.Order>> GetAsync(Expression<Func<Domain.Entity.Order, bool>> predicate)
        {
            return await _context.Orders.Include(x => x.OrderItems).Where(predicate).ToListAsync();
        }
    }
}