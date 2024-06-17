using BikeRent.Domain.Abstractions;
using BikeRent.Domain.Shared;

namespace BikeRent.Domain.Bikes;

public sealed class Bike : Entity
{
    public Bike(
        Guid id,
        string name,
        string description,
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

    public string Name { get; private set; }

    public string Description { get; private set; }

    public Address Address { get; private set; }

    public Money BikeCost { get; private set; }

    public Money PricePerSecond { get; private set; }

    public DateTime? LastRentedOnUtc { get; internal set; }
}
