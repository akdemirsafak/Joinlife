using AutoMapper;
using Event.API.Dtos.Events;
using Event.API.Entities;
using SharedLib.Common;

namespace Event.API.Mapping
{
    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<Eventy, GetEventReponse>()
                .ForMember(dest => dest.EventTypeId, src => src.MapFrom(prop => (int)prop.Type))
                .ForMember(dest => dest.EventType, src => src.MapFrom(prop => prop.Type.ToString()))
                .ForMember(dest => dest.Statu, src => src.MapFrom(prop => prop.Statu.ToString()))
                .ForMember(dest => dest.StatuId, src => src.MapFrom(prop => (int)prop.Statu))
                   .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.Tickets.Select(x => new EventTickets
                   {
                       Id = x.Id,
                       Name = x.Name,
                       Price = x.Price
                   }).ToList()));

            CreateMap<Eventy, GetEventByIdResponse>()
         .ForMember(dest => dest.EventTypeId, src => src.MapFrom(prop => (int)prop.Type))
         .ForMember(dest => dest.EventType, src => src.MapFrom(prop => prop.Type))
         .ForMember(dest => dest.Statu, src => src.MapFrom(prop => prop.Statu.ToString()))
         .ForMember(dest => dest.StatuId, src => src.MapFrom(prop => (int)prop.Statu))
         .ForMember(dest=>dest.Tickets,src=>src.MapFrom(prop=>prop.Tickets))
         .ReverseMap();

            CreateMap<CreateEventRequest, Eventy>()
                .ForMember(dest => dest.Statu, src => src.MapFrom(prop => (EventStatusEnum)prop.StatuId))
                .ForMember(dest => dest.Type, src => src.MapFrom(prop => (EventTypeEnum)prop.EventTypeId));

            CreateMap<Eventy, CreatedEventResponse>()
              .ForMember(dest => dest.EventTypeId, src => src.MapFrom(prop => (int)prop.Type))
                .ForMember(dest => dest.EventType, src => src.MapFrom(prop => prop.Type))
                .ForMember(dest => dest.Statu, src => src.MapFrom(prop => prop.Statu))
                .ForMember(dest => dest.StatuId, src => src.MapFrom(prop => (int)prop.Statu));

            CreateMap<Eventy, UpdatedEventResponse>()
              .ForMember(dest => dest.EventTypeId, src => src.MapFrom(prop => (int)prop.Type))
                .ForMember(dest => dest.EventType, src => src.MapFrom(prop => prop.Type))
                .ForMember(dest => dest.Statu, src => src.MapFrom(prop => prop.Statu))
                .ForMember(dest => dest.StatuId, src => src.MapFrom(prop => (int)prop.Statu));

            CreateMap<UpdateEventRequest, Eventy>()
                .ForMember(dest => dest.Statu, src => src.MapFrom(prop => (EventStatusEnum)prop.StatuId))
                .ForMember(dest => dest.Type, src => src.MapFrom(prop => (EventTypeEnum)prop.EventTypeId))
                .ForMember(dest => dest.UpdatedAt, src => src.MapFrom(prop => DateTime.Now));
        
        }
    }
}