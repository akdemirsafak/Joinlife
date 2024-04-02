using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models.Request.Countries;
using Location.Domain.Models.Response.Countries;
using MediatR;

namespace Location.Application.Features.Country.Commands;

public static class UpdateCountry
{
    public record Command(UpdateCountryRequest Model, Guid Id) : IRequest<UpdatedCountryResponse>;

    public class CommandHandler : IRequestHandler<Command, UpdatedCountryResponse>
    {
        private readonly ICountryService _countryService;

        public CommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<UpdatedCountryResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _countryService.UpdateAsync(request.Model, request.Id);
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
