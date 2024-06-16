using BikeRent.Application.Abstractions.Messaging;

namespace BikeRent.Application.Bikes.SearchBikes
{
    public record SearchBikesQuery(string Name) : IQuery<List<BikeResponse>>;
}
