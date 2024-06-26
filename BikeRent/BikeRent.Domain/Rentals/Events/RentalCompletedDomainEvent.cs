﻿using BikeRent.Domain.Abstractions;

namespace BikeRent.Domain.Rentals.Events;

public sealed record RentalCompletedDomainEvent(Guid RentalId) : IDomainEvent;