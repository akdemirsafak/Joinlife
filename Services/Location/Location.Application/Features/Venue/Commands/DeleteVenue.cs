using FluentValidation;
using Location.Application.Services;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.Venue.Commands;
public static class DeleteVenue
{
    public sealed record Command(Guid id) : IRequest<AppResponse<NoContentResponse>>;

    public class CommandHandler(IVenueService _venueService) : IRequestHandler<Command, AppResponse<NoContentResponse>>
    {
        public async Task<AppResponse<NoContentResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            await _venueService.DeleteAsync(request.id);
            return AppResponse<NoContentResponse>.Success(204);
        }
    }
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.id)
                .NotNull();
        }
    }
}