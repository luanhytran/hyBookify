using FluentValidation;

namespace hyBookify.Application.Bookings.ReservedBooking;

public class ReservedBookingCommandValidator  : AbstractValidator<ReservedBookingCommand>
{
    public ReservedBookingCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        
        RuleFor(c => c.ApartmentId).NotEmpty();

        RuleFor(c => c.StartDate).LessThan(c => c.EndDate);
    }
}