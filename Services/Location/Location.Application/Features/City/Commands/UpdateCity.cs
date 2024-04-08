using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models.Request.Cities;
using Location.Domain.Models.Response.Cities;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.City.Commands;

public static class UpdateCity
{
    public record Command(UpdateCityRequest Model, Guid Id) : IRequest<AppResponse<UpdatedCityResponse>>;

    public class CommandHandler : IRequestHandler<Command, AppResponse<UpdatedCityResponse>>
    {
        private readonly ICityService _cityService;

        public CommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<AppResponse<UpdatedCityResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            var updatedCity= await _cityService.UpdateAsync(request.Model, request.Id);
            return AppResponse<UpdatedCityResponse>.Success(updatedCity, 200);
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
