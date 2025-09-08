using hyBookify.Domain.Abstractions;

namespace hyBookify.Domain.Bookings.Events
{
    public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;

}