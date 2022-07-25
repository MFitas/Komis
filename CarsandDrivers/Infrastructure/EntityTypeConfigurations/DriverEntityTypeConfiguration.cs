using System.Collections.Generic;
using CarsAndDrivers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarsAndDrivers.EntityTypeConfigurations
{
    public class DriverEntityTypeConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder
                .HasKey(x => x.DriverId);

            builder
                .Property(x => x.DriverId)
                .IsRequired();
            
            builder
                .HasMany(x => x.Cars)
                .WithMany(x => x.Drivers)
                .UsingEntity<Dictionary<string, object>>(
                    "CarDriver",
                    r => r.HasOne<Car>()
                        .WithMany()
                        .HasForeignKey("CarId"),
                    l => l.HasOne<Driver>()
                        .WithMany()
                        .HasForeignKey("DriverId")
                );
        }
    }
}