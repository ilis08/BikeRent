using BikeRent.Domain.Abstractions;

namespace BikeRent.Domain.Bikes;

public static class BikeErrors
{
    public static Error NotFound = new("Bike.NotFound", "The bike with the specified identifier was not found");
}
