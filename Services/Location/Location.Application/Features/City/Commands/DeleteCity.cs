using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models;
using MediatR;

namespace Location.Application.Features.City.Commands;

public static class DeleteCity
{
    public record Command(Guid Id) : IRequest<NoContentResponse>;

    public class CommandHandler : IRequestHandler<Command, NoContentResponse>
    {
        private readonly ICityService _cityService;

        public CommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<NoContentResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            await _cityService.DeleteAsync(request.Id);
            return new NoContentResponse();
        }
    }
    public sealed class CommadValidator : AbstractValidator<Command>
    {
        public CommadValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
