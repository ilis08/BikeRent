using BikeRent.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeRent.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(500)
                .HasConversion(name => name.Value, value => new FirstName(value));

            builder.Property(x => x.LastName)
                .HasMaxLength(500)
                .HasConversion(name => name.Value, value => new LastName(value));

            builder.Property(x => x.Email)
                .HasMaxLength(320)
                .HasConversion(description => description.Value, value => new Domain.Users.Email(value));

            builder.HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}
