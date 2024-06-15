using BikeRent.Application.Abstractions.Messaging;
using BikeRent.Domain.Abstractions;

namespace BikeRent.Application.Rentals.GetRental;

internal class GetRentalQueryHandler : IQueryHandler<GetRentalQuery, RentalResponse>
{
    public Task<Result<RentalResponse>> Handle(GetRentalQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
