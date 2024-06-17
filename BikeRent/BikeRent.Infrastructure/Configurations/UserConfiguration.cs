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
                .HasMaxLength(500);

            builder.Property(x => x.LastName)
                .HasMaxLength(500);

            builder.Property(x => x.Email)
                .HasMaxLength(320);

            builder.HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}
