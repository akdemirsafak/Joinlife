using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models.Request.Countries;
using Location.Domain.Models.Response.Countries;
using MediatR;

namespace Location.Application.Features.Country.Commands;

public static class CreateCountry
{
    public record Command(CreateCountryRequest Model) : IRequest<CreatedCountryResponse>;

    public class CommandHandler : IRequestHandler<Command, CreatedCountryResponse>
    {
        private readonly ICountryService _countryService;

        public CommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<CreatedCountryResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _countryService.CreateAsync(request.Model);
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
