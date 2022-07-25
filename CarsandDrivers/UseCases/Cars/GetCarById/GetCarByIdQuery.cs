using CarsAndDrivers.UseCases.Cars.CarsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Cars.GetCarById
{
    public record GetCarByIdQuery : IRequest<CarDTO>
    {
        public int id { get; set; }
    }
}