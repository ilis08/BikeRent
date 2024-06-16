using BikeRent.Domain.Bikes;

namespace BikeRent.Infrastructure.Repositories
{
    internal sealed class BikeRepository : BaseRepository<Bike>, IBikeRepository
    {
        public BikeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
