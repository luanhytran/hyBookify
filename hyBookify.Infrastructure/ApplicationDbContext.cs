using hyBookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace hyBookify.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
        
    }
}