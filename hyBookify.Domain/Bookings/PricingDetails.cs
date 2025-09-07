using hyBookify.Domain.Apartments;
using hyBookify.Domain.Shared;

namespace hyBookify.Domain.Bookings;

public sealed record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);