using BikeRent.Domain.Bikes;

namespace BikeRent.Domain.Rentals;

public interface IRentalRepository
{
    Task<Rental?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(
        Bike bike,
        DateRange duration,
        CancellationToken cancellationToken = default);

    void Add(Rental rental);
}
