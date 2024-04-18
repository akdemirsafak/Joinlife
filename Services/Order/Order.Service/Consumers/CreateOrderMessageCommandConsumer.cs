using MassTransit;
using Order.Domain.Entity;
using Order.Repository.DbContexts;
using SharedLib.Messages;

namespace Order.Service.Consumers;

public class CreateOrderMessageCommandConsumer : IConsumer<CreateOrderMessageCommand>
{
    //private readonly IOrderService _orderService;
    private readonly OrderDbContext _orderDbContext;

    public CreateOrderMessageCommandConsumer(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }



    public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
    {
        var order = new Order.Domain.Entity.Order
        {
            BuyerId= context.Message.BuyerId,
            Statu= StatusEnum.Active,
            //TotalPrice = context.Message.Items.Sum(x => x.Price * x.Quantity),
            //CreatedAt = DateTime.Now,
            OrderItems = context.Message.Items.Select(x => new OrderItem
            {
                EventId = x.EventId,
                EventName = x.EventName,
                Price = x.Price,
                Quantity = x.Quantity,
                TicketId = x.TicketId,
                TicketName = x.TicketName
            }).ToList()
        };

        await _orderDbContext.Orders.AddAsync(order);
        await _orderDbContext.SaveChangesAsync();

    }
}
