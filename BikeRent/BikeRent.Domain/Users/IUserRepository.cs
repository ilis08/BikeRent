using BikeRent.Domain.Abstractions;

namespace BikeRent.Domain.Users;

public interface IUserRepository : IAsyncRepository<User>
{

}
