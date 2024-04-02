using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models.Response.Cities;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.City.Queries;

public static class GetCityById
{
    public record Query(Guid Id) : IRequest<AppResponse<GetCityResponse>>;
    public class QueryHandler : IRequestHandler<Query, AppResponse<GetCityResponse>>
    {
        private readonly ICityService _cityService;

        public QueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<AppResponse<GetCityResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            return AppResponse<GetCityResponse>.Success(await _cityService.GetByIdAsync(request.Id),200);
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
