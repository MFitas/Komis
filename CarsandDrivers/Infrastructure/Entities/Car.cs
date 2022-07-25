using System.Collections.Generic;
using CarsAndDrivers.UseCases.Cars;

namespace CarsAndDrivers.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        
        public int BrandId { get; set; }
        
        public int ModelId { get; set; }
        
        public virtual ICollection<Driver> Drivers { get; set; }
        
        public virtual CarModel Model { get; set; }

    }
}