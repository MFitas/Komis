using System.Collections.Generic;
using CarsAndDrivers.UseCases.Drivers.DriversModels;

namespace CarsAndDrivers.UseCases.Cars.CarsModels
{
    public class CarDTO
    {
        public string BrandName { get; set; }
        
        public string ModelName { get; set; }
        
        public  List<int> OwnersId { get; set; }
    }
}