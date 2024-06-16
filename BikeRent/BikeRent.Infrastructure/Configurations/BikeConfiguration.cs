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
                .HasMaxLength(250)
                .HasConversion(name => name.Value, value => new Name(value));

            builder.Property(x => x.Description)
                .HasMaxLength(5000)
                .HasConversion(description => description.Value, value => new Description(value));

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

            builder.OwnsOne(x => x.InsuranceCost, insuranceCost =>
            {
                insuranceCost.Property(price => price.Currency)
                            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.Property(x => x.LastRentedOnUtc)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();
        }
    }
}
