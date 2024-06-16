using BikeRent.Application.Abstractions.Clock;
using BikeRent.Application.Abstractions.Messaging;
using BikeRent.Application.Exceptions;
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
        var user = await userRepository.FindByIdAsync(request.UserId.ToString(), cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var bike = await bikeRepository.FindByIdAsync(request.BikeId.ToString(), cancellationToken);

        if (bike is null)
        {
            return Result.Failure<Guid>(BikeErrors.NotFound);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        if (await rentalRepository.IsOverlappingAsync(bike, duration, cancellationToken))
        {
            return Result.Failure<Guid>(RentalErrors.Overlap);
        }

        try
        {
            var rental = Rental.Reserve(
                        bike,
                        user.Id,
                        duration,
                        request.additionalServices,
                        utcNow: dateTimeProvider.UtcNow,
                        pricingService);

            await rentalRepository.AddAsync(rental);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return rental.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(RentalErrors.Overlap);
        }
    }
}
