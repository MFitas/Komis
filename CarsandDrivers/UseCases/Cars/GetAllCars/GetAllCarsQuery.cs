using System.Collections.Generic;
using CarsAndDrivers.UseCases.Cars.CarsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Cars.GetAllCars
{
        public record GetAllCarsQuery : IRequest<List<CarDTO>>;
}
