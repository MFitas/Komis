using System.Collections.Generic;

namespace CarsAndDrivers.Infrastructure.Entities
{
    public class CarBrand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }
        
        public virtual ICollection<CarModel> Models { get; set; }
        
        
    }
   
}