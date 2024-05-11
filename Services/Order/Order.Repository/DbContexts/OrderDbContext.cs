using Microsoft.EntityFrameworkCore;
using Order.Domain.Entity;

namespace Order.Repository.DbContexts;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order.Domain.Entity.Order>().Property(prop=>prop.Statu).HasDefaultValue(StatusEnum.Active);
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Order.Domain.Entity.Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}