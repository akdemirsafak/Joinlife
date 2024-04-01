using Joinlife.webui.Entities;
using Joinlife.webui.Models.EventDtos;
using Riok.Mapperly.Abstractions;

namespace Joinlife.webui.Mapping
{
    [Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
    public partial class EventMapper
    {
        [MapEnumValue(nameof(GetEventResponse.EventType), (nameof(Event.EventType)))]
        public partial List<GetEventResponse> EventListToGetEventListResponse(List<Event> events);


        [MapEnumValue(nameof(GetEventByIdResponse.EventType), (nameof(Event.EventType)))]
        public partial GetEventByIdResponse EventToGetEventById(Event organization);

        public GetEventByIdResponse EventToGetEventByIdResponse(Event organization)
        {
            var dto = EventToGetEventById(organization);
            EventTypeEnum eventType = (EventTypeEnum)Enum.Parse(typeof(EventTypeEnum), dto.EventType);
            dto.EventTypeId = (int)eventType;
            return dto;
        }

    }
}