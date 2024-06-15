﻿using BikeRent.Domain.Abstractions;

namespace BikeRent.Domain.Rentals.Events
{
    public sealed record RentalCancelledDomainEvent(Guid RentalId) : IDomainEvent;
}