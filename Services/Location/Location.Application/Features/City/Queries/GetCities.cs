using Location.Application.Services;
using Location.Domain.Models.Response.Cities;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.City.Queries;

public static class GetCities
{
    public record Query() : IRequest<AppResponse<List<GetCityResponse>>>;
    public class QueryHandler : IRequestHandler<Query, AppResponse<List<GetCityResponse>>>
    {
        private readonly ICityService _cityService;

        public QueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<AppResponse<List<GetCityResponse>>> Handle(Query request, CancellationToken cancellationToken)
        {
            return AppResponse<List<GetCityResponse>>.Success(await _cityService.GetAllAsync(),200);
        }
    }
}
