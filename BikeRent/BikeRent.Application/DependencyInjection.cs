using BikeRent.Application.Behaviors;
using BikeRent.Domain.Rentals;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BikeRent.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);

        services.AddTransient<PricingService>();

        return services;
    }
}
