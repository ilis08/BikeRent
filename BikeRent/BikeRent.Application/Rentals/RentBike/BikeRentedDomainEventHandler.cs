using BikeRent.Application.Email;
using BikeRent.Domain.Rentals;
using BikeRent.Domain.Rentals.Events;
using BikeRent.Domain.Users;
using MediatR;

namespace BikeRent.Application.Rentals.RentBike;

internal class BikeRentedDomainEventHandler : INotificationHandler<BikeReservedDomainEvent>
{
    private readonly IRentalRepository rentalRepository;
    private readonly IUserRepository userRepository;
    private readonly IEmailService emailService;

    public BikeRentedDomainEventHandler(
        IRentalRepository rentalRepository,
        IUserRepository userRepository,
        IEmailService emailService)
    {
        this.rentalRepository = rentalRepository;
        this.userRepository = userRepository;
        this.emailService = emailService;
    }

    public async Task Handle(BikeReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var rental = await rentalRepository.GetByIdAsync(notification.RentalId);

        if (rental is null)
        {
            return;
        }

        var user = await userRepository.GetByIdAsync(rental.UserId);

        if (user is null)
        {
            return;
        }

        await emailService.SendAsync(user.Email, "Bike rented!", "Confirm this rent by email");
    }
}
