using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.VenueDtos;

namespace Joinlife.webui.Services
{
    public class VenueService : IVenueService
    {
        private readonly IRepository<Venue> _venueRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        VenueMapper venueMapper = new();

        public VenueService(IRepository<Venue> venueRepository,
            IRepository<City> cityRepository,
            IUnitOfWork unitOfWork)
        {
            _venueRepository = venueRepository;
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateVenueInput input)
        {
            var city = await _cityRepository.GetAsync(x => x.Id == input.CityId);
            if (city is null)
                throw new Exception("City not found.");
            //var entity = venueMapper.CreateVenueInputToVenue(input, city);
            var entity = new Venue
            {
                Name = input.Name,
                Line = input.Line,
                City = city
            };
            await _venueRepository.CreateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var venue = await _venueRepository.GetAsync(x => x.Id == id);
            await _venueRepository.DeleteAsync(venue);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<GetVenueResponse>> GetAllAsync()
        {
            var venues = await _venueRepository.GetAllAsync();
            var response = venueMapper.VenueListToGetVenueResponseList(venues);
            return response;
        }

        public async Task<GetVenueByIdResponse> GetByIdAsync(Guid id)
        {
            Venue venue = await _venueRepository.GetAsync(x => x.Id == id);
            if (venue is null)
                throw new Exception("Venue not found.");

            // return venueMapper.VenueToGetVenueByIdResponse(venue);
            return new GetVenueByIdResponse
            {
                Id = venue.Id,
                Name = venue.Name,
                Line = venue.Line,
                CityId = venue.City.Id,
                CityName = venue.City.Name
            };
        }

        public async Task UpdateAsync(UpdateVenueInput input)
        {
            var city = await _cityRepository.GetAsync(x => x.Id == input.CityId);
            if (city is null)
                throw new Exception("City is not found.");
            // var entity = venueMapper.UpdateVenueInputToVenue(input, city);
            var entity = new Venue
            {
                Id = input.Id,
                Name = input.Name,
                Line = input.Line,
                City = city
            };
            await _venueRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}