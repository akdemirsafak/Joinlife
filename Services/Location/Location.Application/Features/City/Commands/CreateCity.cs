using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models.Request.Cities;
using Location.Domain.Models.Response.Cities;
using MediatR;

namespace Location.Application.Features.City.Commands;

public static class CreateCity
{

    public record Command(CreateCityRequest Model) : IRequest<CreatedCityResponse>;

    public class CommandHandler : IRequestHandler<Command, CreatedCityResponse>
    {

        private readonly ICityService _cityService;

        public CommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<CreatedCityResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _cityService.CreateAsync(request.Model);
        }
    }
    public sealed class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Model.Name)
               .NotNull()
               .Length(2, 32);

            RuleFor(x => x.Model.CountryId)
                .NotNull();
        }
    }
}

