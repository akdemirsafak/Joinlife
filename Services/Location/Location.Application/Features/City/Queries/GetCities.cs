using Location.Application.Services;
using Location.Domain.Models.Response.Cities;
using MediatR;

namespace Location.Application.Features.City.Queries;

public static class GetCities
{
    public record Query() : IRequest<List<GetCityResponse>>;
    public class QueryHandler : IRequestHandler<Query, List<GetCityResponse>>
    {
        private readonly ICityService _cityService;

        public QueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<List<GetCityResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _cityService.GetAllAsync();
        }
    }
}
