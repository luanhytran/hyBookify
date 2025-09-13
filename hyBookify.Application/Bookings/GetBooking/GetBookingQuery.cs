using hyBookify.Application.Abstractions.Messaging;

namespace hyBookify.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>
{
    
}