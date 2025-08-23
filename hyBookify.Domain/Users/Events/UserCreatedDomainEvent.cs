using hyBookify.Domain.Abstractions;

namespace hyBookify.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;