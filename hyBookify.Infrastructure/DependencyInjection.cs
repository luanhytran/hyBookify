using hyBookify.Application.Abstractions.Clock;
using hyBookify.Application.Abstractions.Email;
using hyBookify.Infrastructure.Clock;
using hyBookify.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hyBookify.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        
        services.AddTransient<IEmailService, EmailService>();
        
        return services;
    }
}