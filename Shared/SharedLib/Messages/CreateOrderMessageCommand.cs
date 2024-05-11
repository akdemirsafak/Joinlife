using System;
using System.Collections.Generic;

namespace SharedLib.Messages
{
    public class CreateOrderMessageCommand
    {
        public Guid BuyerId { get; set; }
        public List<OrderItemCreateDto> Items { get; set; } = new List<OrderItemCreateDto>();


    }

    public class OrderItemCreateDto
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public Guid TicketId { get; set; }
        public string TicketName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
