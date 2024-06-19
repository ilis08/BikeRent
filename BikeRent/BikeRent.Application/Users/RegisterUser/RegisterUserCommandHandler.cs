using BikeRent.Application.Abstractions.Messaging;
using BikeRent.Application.Users.RegisterUser;
using BikeRent.Domain.Abstractions;
using BikeRent.Domain.Users;

namespace BikeRent.Application.Rentals.RentBike;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.CreateUser(request.FirstName, request.LastName, request.Email);

        await userRepository.AddAsync(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
