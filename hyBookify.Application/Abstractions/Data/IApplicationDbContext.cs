using hyBookify.Domain.Apartments;
using hyBookify.Domain.Bookings;
using hyBookify.Domain.Reviews;
using hyBookify.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace hyBookify.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Apartment> Apartments { get; }

    DbSet<Booking> Bookings { get; }

    DbSet<Review> Reviews { get; }

    DbSet<User> Users { get; }
}