using FluentValidation;

namespace BikeRent.Application.Rentals.RentBike;

public class RentBikeCommandValidator : AbstractValidator<RentBikeCommand>
{
    public RentBikeCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();

        RuleFor(c => c.BikeId).NotEmpty();

        RuleFor(c => c.StartDate).LessThan(c => c.EndDate);
    }
}
