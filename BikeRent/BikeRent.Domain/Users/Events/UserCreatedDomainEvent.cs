using BikeRent.Domain.Abstractions;

namespace BikeRent.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
}
