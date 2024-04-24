using Location.Persistance.Mapping;
using Location.Application.Services;
using Location.Domain.Entities;
using Location.Domain.Models.Request.Countries;
using Location.Domain.Models.Response.Countries;
using Location.Persistance.Repositories;
using Location.Persistance.UnitOfWorks;

namespace Location.Persistance.Services;

public sealed class CountryService : ICountryService
{
    private readonly IRepository<Country> _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    CountryMapper countryMapper=new CountryMapper();

    public CountryService(IRepository<Country> countryRepository,
        IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreatedCountryResponse> CreateAsync(CreateCountryRequest request)
    {
        var country= countryMapper.CreateCountryRequestToCountry(request);

        var entity= await _countryRepository.CreateAsync(country);

        await _unitOfWork.SaveChangesAsync();
        return countryMapper.CountryToCreatedCountryResponse(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _countryRepository.GetAsync(x => x.Id == id);
        await _countryRepository.DeleteAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<GetCountryResponse>> GetAllAsync()
    {
        var countries = await _countryRepository.GetAllAsync();
        return countryMapper.CountryListToGetCountryListResponse(countries);
    }

    public async Task<GetCountryResponse> GetByIdAsync(Guid id)
    {
        var country = await _countryRepository.GetAsync(x => x.Id == id);
        return countryMapper.CountryToGetCountryResponse(country);
    }

    public async Task<UpdatedCountryResponse> UpdateAsync(UpdateCountryRequest request, Guid id)
    {
        var country = new Country()
        {
            Id = id,
            Name = request.Name,
            ImageUrl = request.ImageUrl
        };
        await _countryRepository.UpdateAsync(country);
        await _unitOfWork.SaveChangesAsync();
        return countryMapper.CountryToUpdatedCountryResponse(country);

    }
}
