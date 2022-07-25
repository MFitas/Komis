using MediatR;

namespace CarsAndDrivers.UseCases.Cars.UpdateCarById
{
    public class UpdateCarByIdCommand : IRequest
    {
        public int Id;
        
        public string Brand { get; set; }
        
        public string Model { get; set; }
    }
}