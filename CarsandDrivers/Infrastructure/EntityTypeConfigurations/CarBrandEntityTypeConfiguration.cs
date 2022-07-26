using CarsAndDrivers.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarsAndDrivers.Infrastructure.EntityTypeConfigurations
{
    public class CarBrandEntityTypeConfiguration : IEntityTypeConfiguration<CarBrand>
    {
        public void Configure(EntityTypeBuilder<CarBrand> builder)
        {
            builder
                .HasKey(x => x.BrandId);

            builder
                .Property(x => x.BrandId).IsRequired();
            
            builder
                .HasMany(x => x.Models)
                .WithOne(x => x.Brand)
                .HasForeignKey(x=>x.BrandId);

            builder
                .HasMany(x => x.Models)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId);



        }
    }
}