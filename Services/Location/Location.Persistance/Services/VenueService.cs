using Location.Application.Mapping;
using Location.Application.Services;
using Location.Domain.Entities;
using Location.Domain.Models.Request.Venue;
using Location.Domain.Models.Response.Venue;
using Location.Persistance.Repositories;
using Location.Persistance.UnitOfWorks;

namespace Location.Persistance.Services;
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

    public async Task<CreatedVenueResponse> CreateAsync(CreateVenueRequest request)
    {
        var city = await _cityRepository.GetAsync(x => x.Id == request.CityId);
        if (city is null)
            throw new Exception("City not found.");
        //var entity = venueMapper.CreateVenueInputToVenue(input, city);
        var entity = new Venue
        {
            Name = request.Name,
            Line = request.Line,
            City = city
        };
        await _venueRepository.CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return venueMapper.VenueToCreatedVenueResponse(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var venue = await _venueRepository.GetAsync(x => x.Id == id);
        await _venueRepository.DeleteAsync(venue);
        await _unitOfWork.SaveChangesAsync();
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

        return venueMapper.VenueToGetVenueByIdResponse(venue);
    }

    public async Task<UpdatedVenueResponse> UpdateAsync(UpdateVenueRequest request, Guid id)
    {
        var venue= await _venueRepository.GetAsync(x=>x.Id == id);
        if (venue is null)
            throw new Exception("Venue not found.");
        var city = await _cityRepository.GetAsync(x => x.Id == request.CityId);
        if (city is null)
            throw new Exception("City not found.");

        venue.Name = request.Name;
        venue.Line = request.Line;
        venue.City = city;
        venue.UpdatedAt = DateTime.Now;

        await _venueRepository.UpdateAsync(venue);
        await _unitOfWork.SaveChangesAsync();

        var updatedResponse=venueMapper.VenueToUpdatedVenueResponse(venue);
        return updatedResponse;

    }
}