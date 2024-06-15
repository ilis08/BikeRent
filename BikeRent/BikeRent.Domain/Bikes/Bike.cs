using BikeRent.Domain.Abstractions;
using BikeRent.Domain.Shared;

namespace BikeRent.Domain.Bikes;

public sealed class Bike : Entity
{
    public Bike(
        Guid id,
        Name name,
        Description description,
        Address address,
        Money pricePerSecond,
        Money insuranceCost) : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        PricePerSecond = pricePerSecond;
        InsuranceCost = insuranceCost;
    }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Address Address { get; private set; }

    public Money BikeCost { get; private set; }

    public Money PricePerSecond { get; private set; }

    public Money InsuranceCost { get; private set; }

    public DateTime? LastRentedOnUtc { get; internal set; }
}
