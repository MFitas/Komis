using MediatR;

namespace CarsAndDrivers.UseCases.Cars.CreateCar
{
    public class AddCarCommand : IRequest
    {
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}