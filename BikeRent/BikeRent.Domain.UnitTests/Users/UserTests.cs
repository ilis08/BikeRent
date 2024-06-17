using BikeRent.Domain.Users;

namespace BikeRent.Domain.UnitTests.Users
{
    public class UserTests
    {
        [Fact]
        public void Create_Should_SetProperties()
        {
            var user = User.CreateUser(UserData.FirstName, UserData.LastName, UserData.Email);

            Assert.NotNull(user);
            Assert.Equal(UserData.FirstName, user.FirstName);
            Assert.Equal(UserData.LastName, user.LastName);
            Assert.Equal(UserData.Email, user.Email);
        }
    }
}
