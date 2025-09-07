using hyBookify.Domain.Abstractions;

namespace hyBookify.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;