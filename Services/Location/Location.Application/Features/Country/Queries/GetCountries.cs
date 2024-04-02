using Location.Application.Services;
using Location.Domain.Models.Response.Countries;
using MediatR;

namespace Location.Application.Features.Country.Queries;

public static class GetCountries
{
    public class Query : IRequest<List<GetCountryResponse>>;

    public class QueryHandler : IRequestHandler<Query, List<GetCountryResponse>>
    {
        private readonly ICountryService _countryService;

        public QueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<List<GetCountryResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _countryService.GetAllAsync();
        }
    }
}
