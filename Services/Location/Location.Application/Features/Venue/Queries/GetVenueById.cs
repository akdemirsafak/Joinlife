using FluentValidation;
using Location.Application.Services;
using Location.Domain.Models.Response.Venue;
using MediatR;
using SharedLib.Dtos;

namespace Location.Application.Features.Venue.Queries;
public static class GetVenueById
{
    public sealed record Query(Guid id) : IRequest<AppResponse<GetVenueByIdResponse>>;

    public class QueryHandler(IVenueService _venueService) : IRequestHandler<Query, AppResponse<GetVenueByIdResponse>>
    {
        public async Task<AppResponse<GetVenueByIdResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            return AppResponse<GetVenueByIdResponse>.Success(await _venueService.GetByIdAsync(request.id), 200);
        }
    }
    public class QueryValidator : AbstractValidator<Query>
    {
        public QueryValidator()
        {
            RuleFor(x => x.id)
                .NotNull();
        }
    }
}