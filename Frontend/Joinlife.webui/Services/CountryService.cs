using Joinlife.webui.Core;
using Joinlife.webui.Core.Repositories;
using Joinlife.webui.Core.Services;
using Joinlife.webui.Entities;
using Joinlife.webui.Mapping;
using Joinlife.webui.Models.Country;

namespace Joinlife.webui.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _repository;
        private readonly IUnitOfWork _unitOfWork;
        CountryMapper countryMapper = new CountryMapper();

        public CountryService(IRepository<Country> repository,
        IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateCountryInput input)
        {
            var isExistCountry = await _repository.GetAsync(x => x.Name == input.Name);
            var entity = countryMapper.CreateCountryInputToCountry(input);
            await _repository.CreateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var country = await _repository.GetAsync(x => x.Id == id);
            if (country is null)
            {
                throw new Exception("Country not found");
            }
            await _repository.DeleteAsync(country);
            await _unitOfWork.CommitAsync();

        }

        public async Task<List<GetCountryResponse>> GetAllAsync()
        {
            var countries = await _repository.GetAllAsync();
            return countryMapper.CountryListToGetCountryListResponse(countries);
        }

        public async Task<GetCountryResponse> GetAsync(Guid id)
        {
            var country = await _repository.GetAsync(x => x.Id == id);
            if (country is null)
                throw new Exception("Country not found");
            return countryMapper.CountryToGetCountryResponse(country);
        }

        public async Task UpdateAsync(UpdateCountryInput input)
        {
            var entity = countryMapper.UpdateCountryInputToCountry(input);
            await _repository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}