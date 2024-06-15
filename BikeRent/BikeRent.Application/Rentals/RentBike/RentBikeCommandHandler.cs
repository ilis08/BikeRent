using BikeRent.Application.Abstractions.Clock;
using BikeRent.Application.Abstractions.Messaging;
using BikeRent.Domain.Abstractions;
using BikeRent.Domain.Bikes;
using BikeRent.Domain.Rentals;
using BikeRent.Domain.Users;

namespace BikeRent.Application.Rentals.RentBike;

internal sealed class RentBikeCommandHandler : ICommandHandler<RentBikeCommand, Guid>
{
    private readonly IUserRepository userRepository;
    private readonly IBikeRepository bikeRepository;
    private readonly IRentalRepository rentalRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly PricingService pricingService;
    private readonly IDateTimeProvider dateTimeProvider;

    public RentBikeCommandHandler(
        IUserRepository userRepository,
        IBikeRepository bikeRepository,
        IRentalRepository rentalRepository,
        IUnitOfWork unitOfWork,
        PricingService pricingService,
        IDateTimeProvider dateTimeProvider)
    {
        this.userRepository = userRepository;
        this.bikeRepository = bikeRepository;
        this.rentalRepository = rentalRepository;
        this.unitOfWork = unitOfWork;
        this.pricingService = pricingService;
        this.dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(RentBikeCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var bike = await bikeRepository.GetByIdAsync(request.BikeId);

        if (bike is null)
        {
            return Result.Failure<Guid>(BikeErrors.NotFound);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        if (await rentalRepository.IsOverlappingAsync(bike, duration, cancellationToken))
        {
            return Result.Failure<Guid>(RentalErrors.Overlap);
        }

        var rental = Rental.Reserve(
            bike,
            user.Id,
            duration,
            request.additionalServices,
            utcNow: dateTimeProvider.UtcNow,
            pricingService);

        rentalRepository.Add(rental);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return rental.Id;
    }
}
