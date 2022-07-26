using System.Collections.Generic;
using CarsAndDrivers.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarsAndDrivers.Infrastructure.EntityTypeConfigurations
{
    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasMany(x => x.Drivers)
                .WithMany(x => x.Cars)
                .UsingEntity<Dictionary<string, object>>(
                    "CarDriver",
                    r => r.HasOne<Driver>()
                        .WithMany()
                        .HasForeignKey("DriverId"),
                    l => l.HasOne<Car>()
                        .WithMany()
                        .HasForeignKey("CarId")
                );
            
            builder
                .HasKey(x => x.CarId);

            builder
                .Property(x => x.CarId).IsRequired();

            builder
                .HasOne(x => x.Model)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.ModelId);


        }
    }
}