using BikeRent.Infrastructure;

namespace BikeRent.Api.Extensions
{
    public static class SeedDataExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            DataSeeder.Seed(dbContext);
        }
    }
}
