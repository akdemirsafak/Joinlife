using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.EventDtos;

namespace Joinlife.webui.Services
{
    public sealed class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;
        private readonly IRepository<Venue> _venueRepository;
        private readonly IRepository<Organizer> _organizerRepository;
        private readonly IUnitOfWork _unitOfWork;
        EventMapper eventMapper = new();

        public EventService(IRepository<Event> eventRepository,
            IRepository<Venue> venueRepository,
            IRepository<Organizer> organizerRepository,
            IUnitOfWork unitOfWork)
        {
            _eventRepository = eventRepository;
            _unitOfWork = unitOfWork;
            _venueRepository = venueRepository;
            _organizerRepository = organizerRepository;
        }

        public async Task CreateAsync(CreateEventInput input)
        {
            var organizer = await _organizerRepository.GetAsync(x => x.Id == input.OrganizerId);
            var venue = await _venueRepository.GetAsync(x => x.Id == input.VenueId);
            Event organization = new Event
            {
                Name = input.Name,
                Description = input.Description,
                Organizer = organizer,
                Venue = venue,
                CreatedAt = DateTime.Now,
                EventType = (EventTypeEnum)input.EventTypeId
            };
            await _eventRepository.CreateAsync(organization);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var organization = await _eventRepository.GetAsync(x => x.Id == id);
            await _eventRepository.DeleteAsync(organization);
            await _unitOfWork.CommitAsync();

        }

        public async Task<List<GetEventResponse>> GetAllAsync()
        {
            var events = await _eventRepository.GetAllAsync();
            return eventMapper.EventListToGetEventListResponse(events);
        }

        public async Task<GetEventByIdResponse> GetAsync(Guid id)
        {
            var organization = await _eventRepository.GetAsync(x => x.Id == id);
            return eventMapper.EventToGetEventByIdResponse(organization);
        }

        public async Task UpdateAsync(UpdateEventInput input)
        {
            var organizer = await _organizerRepository.GetAsync(x => x.Id == input.OrganizerId);
            var venue = await _venueRepository.GetAsync(x => x.Id == input.VenueId);

            var organization = await _eventRepository.GetAsync(x => x.Id == input.Id);
            organization.Name = input.Name;
            organization.Venue = venue;
            organization.Organizer = organizer;
            organization.LastModifiedAt = DateTime.Now;
            organization.EventType = (EventTypeEnum)input.EventTypeId;
            organization.Description = input.Description;

            await _eventRepository.UpdateAsync(organization);
            await _unitOfWork.CommitAsync();
        }
    }
}