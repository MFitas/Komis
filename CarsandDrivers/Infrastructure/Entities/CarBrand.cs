using System;
using System.Collections.Generic;
using CarsAndDrivers.Entities;

namespace CarsAndDrivers.UseCases.Cars
{
    public class CarBrand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }
        
        public virtual ICollection<CarModel> Models { get; set; }
        
        
    }
    // public enum CarBrand
    // {
    //     BMW,
    //     Mini,
    //     RollsRoyce,
    //     Mercedes,
    //     Maybach,
    //     Smart,
    //     Abarth,
    //     AlfaRomeo,
    //     Chrysler,
    //     Dodge,
    //     Ferrari,
    //     Fiat,
    //     Jeep,
    //     Lancia,
    //     Maserati,
    //     Ford,
    //     Lincoln,
    //     Geely,
    //     Polestar,
    //     Volvo,
    //     Xiali,
    //     Buick,
    //     Cadillac,
    //     Chevrolet,
    //     Daewoo,
    //     GMC,
    //     Acura,
    //     Honda,
    //     Genesis,
    //     Hyundai,
    //     Kia,
    //     Mahindra,
    //     SsangYong,
    //     Mazda,
    //     Citroen,
    //     DS,
    //     Peugeot,
    //     Opel,
    //     Vauxhall,
    //     Alpine,
    //     Dacia,
    //     Lada,
    //     Nissan,
    //     Mitsubishi,
    //     Renault,
    //     Subaru,
    //     Suzuki,
    //     Jaguar,
    //     LandRover,
    //     TATA,
    //     Tesla,
    //     Daihatsu,
    //     Lexus,
    //     Scion,
    //     Toyota,
    //     Audi,
    //     Bentley,
    //     Bugatti,
    //     Lamborghini,
    //     Porsche,
    //     Seat,
    //     Skoda,
    //     Volkswagen,
    // }
}