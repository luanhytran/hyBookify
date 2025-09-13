using hyBookify.Domain.Abstractions;

namespace hyBookify.Domain.Apartments;

public static class ApartmentErrors
{
    public static readonly Error NotFound = new(
        "Apartment.NotFound",
        "The apartment with the specified identifier was not found");
}