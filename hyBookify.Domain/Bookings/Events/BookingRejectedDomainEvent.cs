using hyBookify.Domain.Abstractions;

namespace hyBookify.Domain.Bookings.Events
{
    public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
}