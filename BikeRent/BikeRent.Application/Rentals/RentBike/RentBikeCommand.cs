using BikeRent.Application.Abstractions.Messaging;
using BikeRent.Domain.Rentals;

namespace BikeRent.Application.Rentals.RentBike;

public record RentBikeCommand(
    Guid BikeId,
    Guid UserId,
    List<AdditionalService> additionalServices,
    DateTime StartDate,
    DateTime EndDate) : ICommand<Guid>;
