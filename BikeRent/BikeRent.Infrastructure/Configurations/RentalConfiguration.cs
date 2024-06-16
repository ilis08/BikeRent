using BikeRent.Domain.Bikes;
using BikeRent.Domain.Rentals;
using BikeRent.Domain.Shared;
using BikeRent.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeRent.Infrastructure.Configurations
{
    internal sealed class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rental");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Duration);

            builder.Property(x => x.AdditionalServices)
                    .HasConversion(
                        additionalService =>
                                string.Join(",", additionalService.Select(a => a.ToString())),
                        enumsString =>
                                enumsString.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(additionalService => (AdditionalService)Enum.Parse(typeof(AdditionalService), additionalService))
                                .ToList());

            builder.OwnsOne(x => x.PriceForPeriod, priceForPeriod =>
            {
                priceForPeriod.Property(price => price.Currency)
                            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.OwnsOne(x => x.InsuranceFee, insuranceFee =>
            {
                insuranceFee.Property(price => price.Currency)
                            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.OwnsOne(x => x.AdditionalServicesUpCharge, additionalServicesUpCharge =>
            {
                additionalServicesUpCharge.Property(price => price.Currency)
                            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.OwnsOne(x => x.TotalPrice, totalPrice =>
            {
                totalPrice.Property(price => price.Currency)
                            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.HasOne<Bike>()
                .WithMany()
                .HasForeignKey(x => x.BikeId);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
