﻿using BikeRent.Domain.Bikes;
using BikeRent.Domain.Shared;

namespace BikeRent.Domain.Rentals;

public class PricingService
{
    public PricingDetails CalculatePrice(Bike bike, DateRange period, List<AdditionalService> additionalServices)
    {
        var currency = bike.PricePerSecond.Currency;

        int durationInSeconds = (int)Math.Round(period.Duration.TotalSeconds);

        var pricePerPeriod = new Money(bike.PricePerSecond.Amount * durationInSeconds, currency);

        var additionalServicesUpCharge = Money.Zero(currency);

        foreach (var additionalService in additionalServices)
        {
            additionalServicesUpCharge += additionalService switch
            {
                AdditionalService.ProtectiveEquipment => new Money(8, currency),
                AdditionalService.BikeAccessories => new Money(5, currency),
                AdditionalService.DeliveryAndPickup => new Money(4, currency),
                _ => Money.Zero(currency),
            };
        }

        var insuranceFee = new Money(bike.BikeCost.Amount * 0.05m, currency);

        var totalPrice = Money.Zero(currency);

        totalPrice += pricePerPeriod;

        if (!additionalServicesUpCharge.IsZero(currency))
        {
            totalPrice += additionalServicesUpCharge;
        }

        totalPrice += insuranceFee;

        return new PricingDetails(pricePerPeriod, insuranceFee, additionalServicesUpCharge, totalPrice);
    }
}
