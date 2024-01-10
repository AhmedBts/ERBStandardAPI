using Domain.Entities.SecurityModule.Master;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations.SecurityModule.Master
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.CountryName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CountryCode).ValueGeneratedNever();
            builder.HasKey(x => x.CountryCode);
            builder.HasMany(c => c.Citys).WithOne(x => x.country).IsRequired(false);
              
        }
    }
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.CityName).IsRequired().HasMaxLength(200);

            builder.HasKey(x => new { x.CountryCode, x.CityCode });
            builder.Property(x => x.CountryCode).ValueGeneratedNever();
            builder.Property(x => x.CityCode).ValueGeneratedNever();

        }
    }
}