using Location.Application.Services;
using Location.Domain.Models.Response.Countries;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.Country.Queries;

public static class GetCountries
{
    public class Query : IRequest<AppResponse<List<GetCountryResponse>>>;

    public class QueryHandler : IRequestHandler<Query, AppResponse<List<GetCountryResponse>>>
    {
        private readonly ICountryService _countryService;

        public QueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<AppResponse<List<GetCountryResponse>>> Handle(Query request, CancellationToken cancellationToken)
        {
            return AppResponse<List<GetCountryResponse>>.Success(await _countryService.GetAllAsync(), 200);
        }
    }
}
