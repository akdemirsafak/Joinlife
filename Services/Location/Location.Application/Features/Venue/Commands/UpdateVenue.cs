using Location.Application.Services;
using Location.Domain.Models.Request.Venue;
using Location.Domain.Models.Response.Venue;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.Venue.Commands;

public static class UpdateVenue
{
    public sealed record Command(UpdateVenueRequest request, Guid id) : IRequest<AppResponse<UpdatedVenueResponse>>;

    public class CommandHandler(IVenueService _venueService) : IRequestHandler<Command, AppResponse<UpdatedVenueResponse>>
    {
        public async Task<AppResponse<UpdatedVenueResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            return AppResponse<UpdatedVenueResponse>.Success(await _venueService.UpdateAsync(request.request, request.id), 200);
        }
    }
}