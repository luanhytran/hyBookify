using hyBookify.Application.Abstractions.Clock;
using hyBookify.Application.Abstractions.Email;
using hyBookify.Domain.Abstractions;
using hyBookify.Domain.Apartments;
using hyBookify.Domain.Bookings;
using hyBookify.Domain.Users;
using hyBookify.Infrastructure.Clock;
using hyBookify.Infrastructure.Email;
using hyBookify.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hyBookify.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        
        services.AddTransient<IEmailService, EmailService>();
        
        var connectionString =
            configuration.GetConnectionString("Database") ?? 
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IApartmentRepository, ApartmentRepository>();

        services.AddScoped<IBookingRepository, BookingRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}