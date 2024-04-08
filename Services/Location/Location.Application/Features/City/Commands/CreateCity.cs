using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models.Request.Cities;
using Location.Domain.Models.Response.Cities;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.City.Commands;

public static class CreateCity
{

    public record Command(CreateCityRequest Model) : IRequest<AppResponse<CreatedCityResponse>>;

    public class CommandHandler : IRequestHandler<Command, AppResponse<CreatedCityResponse>>
    {

        private readonly ICityService _cityService;

        public CommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<AppResponse<CreatedCityResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            var createdCity = await _cityService.CreateAsync(request.Model);
            return AppResponse<CreatedCityResponse>.Success(createdCity, 201);
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

