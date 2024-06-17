using BikeRent.Domain.Bikes;
using BikeRent.Domain.Shared;
using BikeRent.Domain.Users;

namespace BikeRent.Infrastructure
{
    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            if (!dbContext.Set<User>().Any())
            {
                dbContext.AddRange(
                    User.CreateUser(
                        "John",
                        "Doe",
                        "john.doe@example.com"),
                    User.CreateUser(
                        "Jane",
                        "Smith",
                        "jane.smith@example.com"),
                    User.CreateUser(
                        "Alice",
                        "Johnson",
                        "alice.johnson@example.com"));
            }

            if (!dbContext.Set<Bike>().Any())
            {
                dbContext.AddRange(
                    new Bike(
                        Guid.NewGuid(),
                        "Trek Domane SL 6",
                        "The Trek Domane SL 6 is a performance-oriented road bike designed for endurance rides. It features an IsoSpeed decoupler for added comfort on rough roads, a lightweight carbon frame, and a Shimano Ultegra drivetrain for smooth shifting. This bike is ideal for long-distance rides and competitive cycling.",
                        new Address("United States", "California", "94103", "San Francisco", "123 Market Street"),
                        new Money(1200, Currency.Usd),
                        new Money(0.05m, Currency.Usd)),
                new Bike(
                        Guid.NewGuid(),
                        "Specialized Rockhopper Expert 29",
                        "The Specialized Rockhopper Expert 29 is a versatile and durable mountain bike designed for trail riding. It comes with an aluminum frame, a RockShox Judy fork with 100mm of travel, and a Shimano Deore 1x12 drivetrain. The 29-inch wheels provide stability and smooth rolling over obstacles, making it perfect for off-road adventures.",
                        new Address("United Kingdom", "England", "SW1A 1AA", "London", "789 Buckingham Palace Road"),
                        new Money(2200, Currency.Eur),
                        new Money(0.06m, Currency.Eur)),
                new Bike(
                        Guid.NewGuid(),
                        "Cannondale Quick CX 3",
                        "The Cannondale Quick CX 3 is a hybrid bike designed for both urban commuting and light trail use. It features an aluminum frame, a suspension fork for added comfort, and a Shimano Altus/Acera drivetrain for reliable performance. The bike's upright geometry and comfortable saddle make it an excellent choice for everyday use.",
                        new Address("Bulgaria", "Plovdiv", "4000", "Plovidv", "Street Name"),
                        new Money(5000, Currency.Bgn),
                        new Money(0.08m, Currency.Bgn)));
            }

            dbContext.SaveChanges();
        }
    }
}
