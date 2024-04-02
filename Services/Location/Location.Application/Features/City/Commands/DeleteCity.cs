using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.City.Commands;

public static class DeleteCity
{
    public record Command(Guid Id) : IRequest<AppResponse<NoContentResponse>>;

    public class CommandHandler : IRequestHandler<Command, AppResponse<NoContentResponse>>
    {
        private readonly ICityService _cityService;

        public CommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<AppResponse<NoContentResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            await _cityService.DeleteAsync(request.Id);
            return AppResponse<NoContentResponse>.Success(204);
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
