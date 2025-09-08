using hyBookify.Domain.Abstractions;

namespace hyBookify.Domain.Bookings.Events
{
    public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
}