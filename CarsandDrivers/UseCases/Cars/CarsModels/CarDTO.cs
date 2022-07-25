using System.Collections.Generic;

namespace CarsAndDrivers.UseCases.Cars.CarsModels
{
    public class CarDTO
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        
        public  List<int> OwnersId { get; set; }
    }
}