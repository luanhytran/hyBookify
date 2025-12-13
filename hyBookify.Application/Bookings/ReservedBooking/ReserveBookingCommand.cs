using hyBookify.Application.Abstractions.Messaging;

namespace hyBookify.Application.Bookings.ReservedBooking;

public sealed record ReserveBookingCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<Guid>;