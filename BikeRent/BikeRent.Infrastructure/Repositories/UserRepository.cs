using BikeRent.Domain.Users;

namespace BikeRent.Infrastructure.Repositories
{
    internal sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
