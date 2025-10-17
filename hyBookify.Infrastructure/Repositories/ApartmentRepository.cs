using hyBookify.Domain.Apartments;

namespace hyBookify.Infrastructure.Repositories
{
    internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
