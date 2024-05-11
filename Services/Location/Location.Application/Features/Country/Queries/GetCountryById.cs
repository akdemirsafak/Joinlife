using Location.Application.Services;
using Location.Domain.Models.Response.Countries;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.Country.Queries;

public static class GetCountryById
{
    public record Query(Guid id) : IRequest<AppResponse<GetCountryResponse>>;

    public class QueryHandler : IRequestHandler<Query, AppResponse<GetCountryResponse>>
    {

        private readonly ICountryService _countryService;

        public QueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<AppResponse<GetCountryResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            return AppResponse<GetCountryResponse>.Success(await _countryService.GetByIdAsync(request.id),200);
        }
    }
}
