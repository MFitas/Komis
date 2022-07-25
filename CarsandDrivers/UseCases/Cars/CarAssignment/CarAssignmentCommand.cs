using MediatR;

namespace CarsAndDrivers.UseCases.Cars
{
    public class CarAssignmentCommand : CarAssignmentCommandBody, IRequest
    {
        public  int CarId { get; set; }
        
    }
    public class CarAssignmentCommandBody
    {
        public  int DriverId { get; set; }
        
        
    }
}
