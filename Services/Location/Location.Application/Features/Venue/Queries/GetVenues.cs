using Location.Application.Services;
using Location.Domain.Models.Response.Venue;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.Venue.Queries;
public static class GetVenues
{
    public sealed record Query() : IRequest<AppResponse<List<GetVenueResponse>>>;

    public class QueryHandler(IVenueService _venueService) : IRequestHandler<Query, AppResponse<List<GetVenueResponse>>>
    {
        public async Task<AppResponse<List<GetVenueResponse>>> Handle(Query request, CancellationToken cancellationToken)
        {
            return AppResponse<List<GetVenueResponse>>.Success(await _venueService.GetAllAsync(), 200);
        }
    }
}