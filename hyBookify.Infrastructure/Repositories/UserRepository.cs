using hyBookify.Domain.Users;

namespace hyBookify.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public override void Add(User user)
        {
            DbContext.Add(user);
        }
    }

}
