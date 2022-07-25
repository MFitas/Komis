using MediatR;

namespace CarsAndDrivers.UseCases.Cars.DeleteCar
{
    public class RemoveCarByIdCommand : IRequest
    {
        public int Id { get; set; }
    }
}