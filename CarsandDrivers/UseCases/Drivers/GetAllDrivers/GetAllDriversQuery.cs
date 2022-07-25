using System.Collections.Generic;
using CarsAndDrivers.UseCases.Drivers.DriversModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Drivers.GetAllDrivers
{
    public record GetAllDriversQuery : IRequest<List<DriverDTO>>;

}