using BikeRent.Domain.Abstractions;

namespace BikeRent.Domain.Rentals.Events
{
    public sealed record RentalRejectedDomainEvent(Guid RentalId) : IDomainEvent;
}