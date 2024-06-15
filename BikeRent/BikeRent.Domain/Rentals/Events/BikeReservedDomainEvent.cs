using BikeRent.Domain.Abstractions;

namespace BikeRent.Domain.Rentals.Events
{
    public sealed record BikeReservedDomainEvent(Guid RentalId) : IDomainEvent;
}
