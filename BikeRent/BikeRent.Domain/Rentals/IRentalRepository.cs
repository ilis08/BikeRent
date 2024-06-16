using BikeRent.Domain.Abstractions;
using BikeRent.Domain.Bikes;

namespace BikeRent.Domain.Rentals;

public interface IRentalRepository : IAsyncRepository<Rental>
{
    Task<bool> IsOverlappingAsync(
        Bike bike,
        DateRange duration,
        CancellationToken cancellationToken = default);
}
