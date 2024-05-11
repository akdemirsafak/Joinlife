using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models.Request.Countries;
using Location.Domain.Models.Response.Countries;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.Country.Commands;

public static class UpdateCountry
{
    public record Command(UpdateCountryRequest Model, Guid Id) : IRequest<AppResponse<UpdatedCountryResponse>>;

    public class CommandHandler : IRequestHandler<Command, AppResponse<UpdatedCountryResponse>>
    {
        private readonly ICountryService _countryService;

        public CommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<AppResponse<UpdatedCountryResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            return AppResponse<UpdatedCountryResponse>.Success(await _countryService.UpdateAsync(request.Model, request.Id),200);
        }
    }
    public sealed class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Model.Name)
                .NotNull()
                .Length(2, 32);
        }
    }
}
