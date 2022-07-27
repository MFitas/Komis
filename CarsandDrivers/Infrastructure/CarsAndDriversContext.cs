using CarsAndDrivers.Infrastructure.Entities;
using CarsAndDrivers.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarsAndDrivers.Infrastructure
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