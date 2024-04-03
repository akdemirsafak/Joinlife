using AutoMapper;
using Event.API.Dtos;
using Event.API.Entities;

namespace Event.API.Mapping
{
    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<Eventy, GetEventReponse>()
                .ForMember(dest => dest.EventTypeId, src => src.MapFrom(prop => (int)prop.Type))
                .ForMember(dest => dest.EventType, src => src.MapFrom(prop => prop.Type))
                .ForMember(dest => dest.Statu, src => src.MapFrom(prop => prop.Statu))
                .ForMember(dest => dest.StatuId, src => src.MapFrom(prop => (int)prop.Statu));

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
        }
    }
}