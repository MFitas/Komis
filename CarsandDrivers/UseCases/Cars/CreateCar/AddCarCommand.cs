using MediatR;

namespace CarsAndDrivers.UseCases.Cars.CreateCar
{
    public class AddCarCommand : IRequest
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}