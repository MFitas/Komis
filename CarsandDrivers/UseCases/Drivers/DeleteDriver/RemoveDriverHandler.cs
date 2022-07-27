using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Drivers.DeleteDriver
{
    public class RemoveDriverHandler : IRequestHandler<RemoveDriverCommand>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public RemoveDriverHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }

        public async Task<Unit> Handle(RemoveDriverCommand command, CancellationToken cancellationToken)
        {
            var driverToRemove =  await _carsDriversContext.Drivers
                .Where(dr => dr.DriverId == command.Id)
                .FirstOrDefaultAsync(cancellationToken);
            
             _carsDriversContext.Remove(driverToRemove);
             
            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }


    }
}