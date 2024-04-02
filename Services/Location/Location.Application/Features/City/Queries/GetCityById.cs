using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models.Response.Cities;
using MediatR;

namespace Location.Application.Features.City.Queries;

public static class GetCityById
{
    public record Query(Guid Id) : IRequest<GetCityResponse>;
    public class QueryHandler : IRequestHandler<Query, GetCityResponse>
    {
        private readonly ICityService _cityService;

        public QueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<GetCityResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _cityService.GetByIdAsync(request.Id);
        }
    }
    public sealed class QueryValidator : AbstractValidator<Query>
    {
        public QueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull();
        }
    }
}
