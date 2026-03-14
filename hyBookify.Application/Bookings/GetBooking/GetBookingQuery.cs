using hyBookify.Application.Abstractions.Caching;

namespace hyBookify.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : ICachedQuery<BookingResponse>
{
    public string CacheKey => $"bookings-{BookingId}";

    public TimeSpan? Expiration => null;
}