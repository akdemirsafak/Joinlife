using System;
using System.Collections.Generic;

namespace SharedLib.Messages
{
    public class CreateOrderNotificationMessageCommand
    {
        public string Email { get; set; }
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }

    public class OrderItemDto
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public Guid TicketId { get; set; }
        public string TicketName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
