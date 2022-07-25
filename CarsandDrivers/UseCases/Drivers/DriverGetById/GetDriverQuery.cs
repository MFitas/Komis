using CarsAndDrivers.UseCases.Drivers.DriversModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Drivers.DriverGetById
{
    public record GetDriverQuery : IRequest<DriverWithoutCarDTO>
    {
        public int Id { get; set; }
    }

}