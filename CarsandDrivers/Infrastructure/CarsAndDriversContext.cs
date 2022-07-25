using System.Collections.Generic;
using CarsAndDrivers.Entities;
using CarsAndDrivers.EntityTypeConfigurations;
using CarsAndDrivers.UseCases.Cars;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers
{
    public class CarsDriversContext : DbContext
    {

        public CarsDriversContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<CarBrand> CarBrands { get; set; }
        
        public DbSet<CarModel> CarModels { get; set; }


       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            new DriverEntityTypeConfiguration().Configure(modelBuilder.Entity<Driver>());
            new CarEntityTypeConfiguration().Configure(modelBuilder.Entity<Car>());
            
            new CarModelEntityTypeConfiguration().Configure(modelBuilder.Entity<CarModel>());
            new CarBrandEntityTypeConfiguration().Configure(modelBuilder.Entity<CarBrand>());
       }
        
    }
    
}