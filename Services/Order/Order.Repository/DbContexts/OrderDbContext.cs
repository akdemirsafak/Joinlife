using Microsoft.EntityFrameworkCore;
using Order.Domain.Entity;

namespace Order.Repository.DbContexts
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
        public DbSet<Order.Domain.Entity.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}