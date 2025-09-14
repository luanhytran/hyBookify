using hyBookify.Application.Abstractions.Clock;

namespace hyBookify.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}