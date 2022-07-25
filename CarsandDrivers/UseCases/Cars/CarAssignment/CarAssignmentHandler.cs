using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CarsAndDrivers.UseCases.Cars
{
    public class CarAssignmentHandler : IRequestHandler<CarAssignmentCommand>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public CarAssignmentHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }

        public async Task<Unit> Handle(CarAssignmentCommand command,
            CancellationToken cancellationToken)
        {
            var car = await _carsDriversContext.Cars
                .Where(cr => cr.CarId == command.CarId)
                .FirstOrDefaultAsync(cancellationToken);

            var driver = await _carsDriversContext.Drivers
                .Where((dr => dr.DriverId == command.DriverId))
                .FirstOrDefaultAsync(cancellationToken);
            
            

            driver.Cars.Add(car);

            await _carsDriversContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}