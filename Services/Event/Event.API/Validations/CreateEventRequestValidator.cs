using Event.API.Dtos.Events;
using FluentValidation;

namespace Event.API.Validations
{
    public class CreateEventRequestValidator : AbstractValidator<CreateEventRequest>
    {
        public CreateEventRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(2, 32);

            RuleFor(x => x.Description)
                .MaximumLength(255);

            RuleFor(x => x.VenueId)
                .NotNull();

            RuleFor(x => x.StatuId)
                .GreaterThan(0);

            RuleFor(x => x.EventTypeId)
                .GreaterThan(0);

            RuleFor(x => x.StartDateTime);

            RuleFor(x => x.EndDateTime)
                .Must(predicate: (request, endDateTime) => endDateTime > request.StartDateTime);
        }
    }
}