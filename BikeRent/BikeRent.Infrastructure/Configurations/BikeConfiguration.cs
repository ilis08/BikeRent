using BikeRent.Domain.Bikes;
using BikeRent.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeRent.Infrastructure.Configurations
{
    internal sealed class BikeConfiguration : IEntityTypeConfiguration<Bike>
    {
        public void Configure(EntityTypeBuilder<Bike> builder)
        {
            builder.ToTable("Bikes");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Address);

            builder.Property(x => x.Name)
                .HasMaxLength(250);

            builder.Property(x => x.Description)
                .HasMaxLength(5000);

            builder.OwnsOne(x => x.BikeCost, bikeCost =>
            {
                bikeCost.Property(price => price.Currency)
                            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.OwnsOne(x => x.PricePerSecond, pricePerSecondBuilder =>
            {
                pricePerSecondBuilder.Property(price => price.Currency)
                            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.Property(x => x.LastRentedOnUtc)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();
        }
    }
}
