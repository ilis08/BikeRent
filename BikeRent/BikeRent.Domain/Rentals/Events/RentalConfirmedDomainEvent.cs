using BikeRent.Domain.Abstractions;

namespace BikeRent.Domain.Rentals.Events;

public sealed record RentalConfirmedDomainEvent(Guid RentalId) : IDomainEvent;