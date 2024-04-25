using Location.Persistance.Mapping;
using Location.Application.Services;
using Location.Domain.Entities;
using Location.Domain.Models.Request.Cities;
using Location.Domain.Models.Response.Cities;
using Location.Persistance.Repositories;
using Location.Persistance.UnitOfWorks;

namespace Location.Persistance.Services;

public sealed class CityService : ICityService
{
    private readonly IRepository<City> _cityRepository;
    private readonly IRepository<Country> _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    CityMapper cityMapper = new();

    public CityService(IRepository<City> cityRepository,
        IRepository<Country> countryRepository,
        IUnitOfWork unitOfWork)
    {
        _cityRepository = cityRepository;
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreatedCityResponse> CreateAsync(CreateCityRequest request)
    {
        var country = await _countryRepository.GetAsync(x => x.Id == request.CountryId);
        var city = cityMapper.CreateCityRequestToCity(request);
        city.Country = country;

        await _cityRepository.CreateAsync(city);
        await _unitOfWork.SaveChangesAsync();
        return cityMapper.CityToCreatedCityResponse(city);
    }

    public async Task DeleteAsync(Guid id)
    {
        var city= await _cityRepository.GetAsync(x=>x.Id==id);

        await _cityRepository.DeleteAsync(city);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<GetCityResponse>> GetAllAsync()
    {
        var cities= await _cityRepository.GetAllAsync();
        return cityMapper.CityListToGetCityResponseList(cities);
    }

    public async Task<GetCityResponse> GetByIdAsync(Guid id)
    {
        var city= await _cityRepository.GetAsync(x=>x.Id==id);
        return cityMapper.CityToGetCityResponse(city);
    }

    public async Task<UpdatedCityResponse> UpdateAsync(UpdateCityRequest request, Guid id)
    {
        var country= await _countryRepository.GetAsync(x => x.Id == request.CountryId);

        var city= await _cityRepository.GetAsync(x=>x.Id==id);
        city = cityMapper.UpdateCityRequestToCity(request);
        city.Country= country;
        await _cityRepository.UpdateAsync(city);
        await _unitOfWork.SaveChangesAsync();
        return cityMapper.CityToUpdatedCityResponse(city);
    }
}
