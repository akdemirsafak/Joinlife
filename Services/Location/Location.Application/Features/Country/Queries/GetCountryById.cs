using Location.Application.Services;
using Location.Domain.Models.Response.Countries;
using MediatR;

namespace Location.Application.Features.Country.Queries;

public static class GetCountryById
{
    public record Query(Guid id) : IRequest<GetCountryResponse>;

    public class QueryHandler : IRequestHandler<Query, GetCountryResponse>
    {

        private readonly ICountryService _countryService;

        public QueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<GetCountryResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _countryService.GetByIdAsync(request.id);
        }
    }
}
