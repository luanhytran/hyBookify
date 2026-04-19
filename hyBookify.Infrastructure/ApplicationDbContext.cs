using hyBookify.Application.Exceptions;
using hyBookify.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using hyBookify.Application.Abstractions.Data;
using hyBookify.Domain.Apartments;
using hyBookify.Domain.Bookings;
using hyBookify.Domain.Reviews;
using hyBookify.Domain.Users;

namespace hyBookify.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
{
    private readonly IPublisher _publisher;
    
    public DbSet<Apartment> Apartments { get; private set; }

    public DbSet<Booking> Bookings { get; private set; }

    public DbSet<Review> Reviews { get; private set; }

    public DbSet<User> Users { get; private set; }

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEventAsync();

            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", ex);
        }
    }

    private async Task PublishDomainEventAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }
}