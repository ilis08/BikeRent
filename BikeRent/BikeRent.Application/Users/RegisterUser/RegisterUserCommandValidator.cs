using BikeRent.Application.Users.RegisterUser;
using FluentValidation;

namespace BikeRent.Application.Rentals.RentBike;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();

        RuleFor(c => c.LastName).NotEmpty();

        RuleFor(c => c.Email).EmailAddress();
    }
}
