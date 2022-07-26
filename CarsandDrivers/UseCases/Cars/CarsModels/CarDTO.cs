using System.Collections.Generic;

namespace CarsAndDrivers.UseCases.Cars.CarsModels
{
    public class CarDTO
    {
        public int BrandId { get; set; }
        
        public int ModelId { get; set; }
        
        public  List<int> OwnersId { get; set; }
    }
}