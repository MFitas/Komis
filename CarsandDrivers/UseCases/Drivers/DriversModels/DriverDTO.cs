using System.Collections.Generic;
using CarsAndDrivers.UseCases.Cars.CarsModels;

namespace CarsAndDrivers.UseCases.Drivers.DriversModels
{
    public  class DriverDTO
    {
        public string FirstName { get; set; }
        
        public  string SecondName { get; set; }
        
        public string Occupation { get; set; }
        
        public List<CarDTO> CarInfo { get; set; }

    }
}