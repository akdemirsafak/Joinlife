using AutoMapper;
using Event.API.Dtos.Tickets;
using Event.API.Entities;

namespace Event.API.Mapping;

public sealed class TicketMapper : Profile
{
    public TicketMapper()
    {
        CreateMap<Tickety, CreatedTicketResponse>();
        CreateMap<CreateTicketRequest, Tickety>();
        CreateMap<Tickety, GetTicketResponse>().ReverseMap();
        CreateMap<Tickety, UpdatedTicketResponse>();
    }
}
