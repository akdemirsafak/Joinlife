using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models.Request.Cities;
using Location.Domain.Models.Response.Cities;
using MediatR;

namespace Location.Application.Features.City.Commands;

public static class UpdateCity
{
    public record Command(UpdateCityRequest Model, Guid Id) : IRequest<UpdatedCityResponse>;

    public class CommandHandler : IRequestHandler<Command, UpdatedCityResponse>
    {
        private readonly ICityService _cityService;

        public CommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<UpdatedCityResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _cityService.UpdateAsync(request.Model, request.Id);
        }
    }
    public sealed class CommadValidator : AbstractValidator<Command>
    {
        public CommadValidator()
        {
            RuleFor(x => x.Model.Name)
                .NotNull()
                .Length(2, 32);

            RuleFor(x => x.Model.CountryId)
                .NotNull();
        }
    }

}
