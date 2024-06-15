using BikeRent.Domain.Abstractions;
using BikeRent.Domain.Users.Events;

namespace BikeRent.Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid id, FirstName firstName, LastName lastName, Email email) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public FirstName FirstName { get; private set; }

        public LastName LastName { get; private set; }

        public Email Email { get; private set; }

        public static User CreateUser(FirstName firstName, LastName lastName, Email email)
        {
            var user = new User(Guid.NewGuid(), firstName, lastName, email);

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }
    }
}
