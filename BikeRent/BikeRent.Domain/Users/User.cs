using BikeRent.Domain.Abstractions;
using BikeRent.Domain.Users.Events;

namespace BikeRent.Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, string firstName, string lastName, string email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public User()
    {
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public static User CreateUser(string firstName, string lastName, string email)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}
