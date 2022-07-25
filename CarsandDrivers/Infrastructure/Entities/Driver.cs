using System.Collections.Generic;

namespace CarsAndDrivers.Entities
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Occupation { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

        public override string ToString()
        {
            return $"{DriverId}, \n{FirstName}, \n{SecondName}, \n{Occupation}";
        }
    }

   
}