using BikeRent.Domain.Abstractions;

namespace BikeRent.Domain.Rentals
{
    public static class RentalErrors
    {
        public static Error NotFound = new("Rental.NotFound", "The bike with the specified identifier was not found");
        public static Error Overlap = new("Rental.AlreadyInRent", "The current rent is overlapped with another one");
        public static Error NotReserved = new("Rental.NotReserved", "The rent is not pending");
        public static Error NotConfirmed = new("Rental.NotConfirmed", "The rent is not confirmed");
        public static Error RentInProgress = new("Rental.NotConfirmed", "The rent is in progress");
    }
}
