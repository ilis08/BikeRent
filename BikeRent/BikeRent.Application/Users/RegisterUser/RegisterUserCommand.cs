using BikeRent.Application.Abstractions.Messaging;

namespace BikeRent.Application.Users.RegisterUser
{
    public record RegisterUserCommand(
    string FirstName,
    string LastName,
    string Email) : ICommand<Guid>;
}
