﻿using Joinlife.webui.Models.EventDtos;

namespace Joinlife.webui.Models.Tickets;

public class TicketViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid EventId { get; set; }
    public string EventName { get; set; }
    public string EventImageUrl { get; set; }
    //public virtual GetEventResponse Event { get; set; }
}