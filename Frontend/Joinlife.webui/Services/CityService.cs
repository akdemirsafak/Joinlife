using Joinlife.webui.Core;
using Joinlife.webui.Core.Repositories;
using Joinlife.webui.Core.Services;
using Joinlife.webui.Entities;
using Joinlife.webui.Mapping;
using Joinlife.webui.Models.City;

namespace Joinlife.webui.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        CityMapper cityMapper = new CityMapper();

        public CityService(IRepository<City> cityRepository,
        IRepository<Country> countryRepository,
        IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateCityInput input)
        {
            var country = await _countryRepository.GetAsync(x => x.Id == input.CountryId);
            var city = new City
            {
                Name = input.Name,
                Country = country
            };
            await _cityRepository.CreateAsync(city);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var city = await _cityRepository.GetAsync(x => x.Id == id);
            if (city is null)
                throw new Exception("City not found");
            await _cityRepository.DeleteAsync(city);
            await _unitOfWork.CommitAsync();

        }

        public async Task<List<GetCityResponse>> GetAllAsync()
        {
            var countries = await _cityRepository.GetAllAsync();
            return cityMapper.CityListToGetCityListResponse(countries);
        }

        public async Task<GetCityResponse> GetAsync(Guid id)
        {
            var city = await _cityRepository.GetAsync(x => x.Id == id);
            if (city is null)
                throw new Exception("City not found");
            return cityMapper.CityToGetCityResponse(city);
        }

        public async Task UpdateAsync(UpdateCityInput input)
        {
            var city = cityMapper.CityToUpdateCityInput(input);

            //Country ile ilgili durumlar yapılması gerekli
            await _cityRepository.UpdateAsync(city);
            await _unitOfWork.CommitAsync();
        }
    }
}