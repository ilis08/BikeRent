using BikeRent.Domain.Shared;

namespace BikeRent.Domain.Rentals;

public record PricingDetails(
    Money PriceForPeriod,
    Money InsuranceFee,
    Money AdditionalServicesUpCharge,
    Money TotalPrice);
