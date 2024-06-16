using BikeRent.Application.Abstractions.Messaging;
using BikeRent.Domain.Abstractions;
using BikeRent.Domain.Bikes;

namespace BikeRent.Application.Bikes.SearchBikes
{
    internal sealed class SearchBikeQueryHandler : IQueryHandler<SearchBikesQuery, List<BikeResponse>>
    {
        private readonly IBikeRepository bikeRepository;

        public SearchBikeQueryHandler(IBikeRepository bikeRepository)
        {
            this.bikeRepository = bikeRepository;
        }

        public async Task<Result<List<BikeResponse>>> Handle(SearchBikesQuery request, CancellationToken cancellationToken)
        {
            var bikes = await bikeRepository
                .FindByConditionAsync(x => x.Name.Value.Equals(request.Name), cancellationToken);

            List<BikeResponse> response = bikes.Select(x => new BikeResponse
            {
                Name = x.Name.Value,
                Description = x.Description.Value,
                Country = x.Address.Country,
                State = x.Address.State,
                ZipCode = x.Address.ZipCode,
                City = x.Address.City,
                Street = x.Address.Street,
                BikeCost = x.BikeCost.Amount,
                BikeCostCurrency = x.BikeCost.Currency.Code,
                PricePerSecond = x.PricePerSecond.Amount,
                PricePerSecondCurrency = x.PricePerSecond.Currency.Code,
                LastRentedOnUtc = x.LastRentedOnUtc,
            }).ToList();

            return response;
        }
    }
}
