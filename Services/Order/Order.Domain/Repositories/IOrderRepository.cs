
namespace Order.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order.Domain.Entity.Order>> GetAllAsync();
        Task<Order.Domain.Entity.Order> GetByIdAsync(Guid id);

        Task<Order.Domain.Entity.Order> CreateAsync(Order.Domain.Entity.Order order);

    }
}