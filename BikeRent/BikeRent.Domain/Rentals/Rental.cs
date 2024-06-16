using BikeRent.Domain.Abstractions;
using BikeRent.Domain.Bikes;
using BikeRent.Domain.Rentals.Events;
using BikeRent.Domain.Shared;

namespace BikeRent.Domain.Rentals;

public sealed class Rental : Entity
{
    private Rental(
        Guid id,
        Guid bikeId,
        Guid userId,
        DateRange duration,
        Money priceForPeriod,
        Money insuranceFee,
        Money additionalServicesUpCharge,
        Money totalPrice,
        RentalStatus rentalStatus,
        DateTime createdOnUtc)
        : base(id)
    {
        BikeId = bikeId;
        UserId = userId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        InsuranceFee = insuranceFee;
        AdditionalServicesUpCharge = additionalServicesUpCharge;
        TotalPrice = totalPrice;
        RentalStatus = rentalStatus;
        CreatedOnUtc = createdOnUtc;
    }

    public Rental()
    {
    }

    public Guid BikeId { get; private set; }

    public Guid UserId { get; private set; }

    public ICollection<AdditionalService> AdditionalServices { get; private set; } = [];

    public DateRange Duration { get; private set; }

    public Money PriceForPeriod { get; private set; }

    public Money InsuranceFee { get; private set; }

    public Money AdditionalServicesUpCharge { get; private set; }

    public Money TotalPrice { get; private set; }

    public RentalStatus RentalStatus { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? ConfirmedOnUtc { get; private set; }

    public DateTime? RejectedOnUtc { get; private set; }

    public DateTime? CompletedOnUtc { get; private set; }

    public DateTime? CancelledOnUtc { get; private set; }

    public static Rental Reserve(
        Bike bike,
        Guid userId,
        DateRange duration,
        List<AdditionalService> additionalServices,
        DateTime utcNow,
        PricingService pricingService)
    {
        var pricingDetails = pricingService.CalculatePrice(bike, duration, additionalServices);

        var rental = new Rental(
            Guid.NewGuid(),
            bike.Id,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.InsuranceFee,
            pricingDetails.AdditionalServicesUpCharge,
            pricingDetails.TotalPrice,
            RentalStatus.Reserved,
            utcNow);

        rental.RaiseDomainEvent(new BikeReservedDomainEvent(rental.Id));

        bike.LastRentedOnUtc = utcNow;

        return rental;
    }

    public Result Confirm(DateTime utcNow)
    {
        if (RentalStatus != RentalStatus.Reserved)
        {
            return Result.Failure(RentalErrors.NotReserved);
        }

        RentalStatus = RentalStatus.Confirmed;
        ConfirmedOnUtc = utcNow;

        RaiseDomainEvent(new RentalConfirmedDomainEvent(Id));

        return Result.Success();
    }

    public Result Reject(DateTime utcNow)
    {
        if (RentalStatus != RentalStatus.Reserved)
        {
            return Result.Failure(RentalErrors.NotReserved);
        }

        RentalStatus = RentalStatus.Rejected;
        RejectedOnUtc = utcNow;

        RaiseDomainEvent(new RentalRejectedDomainEvent(Id));

        return Result.Success();
    }

    public Result Complete(DateTime utcNow)
    {
        if (RentalStatus != RentalStatus.Confirmed)
        {
            return Result.Failure(RentalErrors.NotConfirmed);
        }

        RentalStatus = RentalStatus.Completed;
        CompletedOnUtc = utcNow;

        RaiseDomainEvent(new RentalCompletedDomainEvent(Id));

        return Result.Success();
    }

    public Result Cancel(DateTime utcNow)
    {
        if (RentalStatus != RentalStatus.Confirmed)
        {
            return Result.Failure(RentalErrors.NotConfirmed);
        }

        if (utcNow > Duration.Start)
        {
            return Result.Failure(RentalErrors.RentInProgress);
        }

        RentalStatus = RentalStatus.Cancelled;
        CancelledOnUtc = utcNow;

        RaiseDomainEvent(new RentalCancelledDomainEvent(Id));

        return Result.Success();
    }
}
