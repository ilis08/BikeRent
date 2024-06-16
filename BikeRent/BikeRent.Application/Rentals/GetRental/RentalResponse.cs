namespace BikeRent.Application.Rentals.GetRental;

public class RentalResponse
{
    public Guid Id { get; set; }

    public Guid BikeId { get; init; }

    public Guid UserId { get; init; }

    public ICollection<int> AdditionalServices { get; init; } = [];

    public DateTime DurationStart { get; init; }

    public DateTime DurationEnd { get; init; }

    public decimal PriceAmount { get; init; }

    public string PriceCurrency { get; init; }

    public decimal InsuranceFee { get; init; }

    public string InsuranceFeeCurrency { get; init; }

    public decimal AdditionalServicesUpCharge { get; init; }

    public string AdditionalServicesUpChargeCurrency { get; init; }

    public decimal TotalPrice { get; init; }

    public string TotalPriceCurrency { get; init; }

    public int RentalStatus { get; init; }

    public DateTime CreatedOnUtc { get; init; }
}
