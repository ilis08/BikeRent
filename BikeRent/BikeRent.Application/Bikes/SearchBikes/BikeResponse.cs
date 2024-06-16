namespace BikeRent.Application.Bikes.SearchBikes
{
    public class BikeResponse
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public string Country { get; init; }

        public string State { get; init; }

        public string ZipCode { get; init; }

        public string City { get; init; }

        public string Street { get; init; }

        public decimal BikeCost { get; init; }

        public string BikeCostCurrency { get; init; }

        public decimal PricePerSecond { get; init; }

        public string PricePerSecondCurrency { get; init; }

        public DateTime? LastRentedOnUtc { get; internal set; }
    }
}
