namespace BikeRent.Domain.Bikes;

public interface IBikeRepository
{
    Task<Bike?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
