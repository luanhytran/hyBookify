using hyBookify.Domain.Abstractions;

namespace hyBookify.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;