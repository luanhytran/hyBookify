using hyBookify.Domain.Abstractions;

namespace hyBookify.Domain.Bookings.Events
{
    public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;

}