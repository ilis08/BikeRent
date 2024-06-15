using BikeRent.Application.Abstractions.Messaging;

namespace BikeRent.Application.Rentals.GetRental;

public record GetRentalQuery(Guid RentalId) : IQuery<RentalResponse>;
