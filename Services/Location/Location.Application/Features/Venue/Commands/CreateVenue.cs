using Location.Application.Services;
using Location.Domain.Models.Request.Venue;
using Location.Domain.Models.Response.Venue;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.Venue.Commands;
public static class CreateVenue
{
    public sealed record Command(CreateVenueRequest Model) : IRequest<AppResponse<CreatedVenueResponse>>;

    public class CommandHandler(IVenueService _venueService) : IRequestHandler<Command, AppResponse<CreatedVenueResponse>>
    {
        public async Task<AppResponse<CreatedVenueResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            return AppResponse<CreatedVenueResponse>.Success(await _venueService.CreateAsync(request.Model), 201);
        }
    }
}