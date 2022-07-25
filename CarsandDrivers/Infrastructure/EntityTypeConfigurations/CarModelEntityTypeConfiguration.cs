using CarsAndDrivers.Entities;
using CarsAndDrivers.UseCases.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarsAndDrivers.EntityTypeConfigurations
{
    public class CarModelEntityTypeConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder
                .HasKey(x => x.ModelId);
            
            builder
                .Property(x => x.ModelId)
                .IsRequired();
            
            builder
                .HasOne(x => x.Brand)
                .WithMany(x => x.Models)
                .HasForeignKey(x=>x.BrandId);

            builder
                .HasMany(x => x.Cars)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId);

            builder
                .HasOne(x => x.Brand)
                .WithMany(x => x.Models)
                .HasForeignKey(x => x.BrandId);

        }
    }
}