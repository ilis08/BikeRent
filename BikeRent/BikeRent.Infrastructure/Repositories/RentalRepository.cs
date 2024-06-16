using BikeRent.Domain.Bikes;
using BikeRent.Domain.Rentals;
using Microsoft.EntityFrameworkCore;

namespace BikeRent.Infrastructure.Repositories
{
    internal sealed class RentalRepository : BaseRepository<Rental>, IRentalRepository
    {
        private static readonly RentalStatus[] ActiveRentalStatuses = [
            RentalStatus.Reserved,
            RentalStatus.Confirmed,
            RentalStatus.Completed,
        ];

        public RentalRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsOverlappingAsync(Bike bike, DateRange duration, CancellationToken cancellationToken = default)
        {
            return await dbContext
                .Set<Rental>()
                .AnyAsync(rental =>
                    rental.BikeId == bike.Id &&
                    rental.Duration.Start <= duration.End &&
                    rental.Duration.End >= duration.Start &&
                    ActiveRentalStatuses.Contains(rental.RentalStatus), cancellationToken);

        }
    }
}
