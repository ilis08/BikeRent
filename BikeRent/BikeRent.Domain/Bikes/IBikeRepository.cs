using BikeRent.Domain.Abstractions;

namespace BikeRent.Domain.Bikes;

public interface IBikeRepository : IAsyncRepository<Bike>
{
}
