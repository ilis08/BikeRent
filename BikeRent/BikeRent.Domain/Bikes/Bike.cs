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
        Money bikeCost,
        Money pricePerSecond) : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        BikeCost = bikeCost;
        PricePerSecond = pricePerSecond;
    }

    private Bike()
    {
    }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Address Address { get; private set; }

    public Money BikeCost { get; private set; }

    public Money PricePerSecond { get; private set; }

    public DateTime? LastRentedOnUtc { get; internal set; }
}
