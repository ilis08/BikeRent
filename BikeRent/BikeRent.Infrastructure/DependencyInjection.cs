﻿using BikeRent.Application.Abstractions.Clock;
using BikeRent.Application.Email;
using BikeRent.Domain.Abstractions;
using BikeRent.Domain.Bikes;
using BikeRent.Domain.Rentals;
using BikeRent.Domain.Users;
using BikeRent.Infrastructure.Clock;
using BikeRent.Infrastructure.Email;
using BikeRent.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BikeRent.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        var dbConnectionString = configuration.GetConnectionString("DefaultConnection") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(dbConnectionString);
        });

        services.AddTransient<IEmailService, EmailService>();

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IBikeRepository, BikeRepository>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IRentalRepository, RentalRepository>();

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
