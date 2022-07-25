using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Drivers.UpdateDriverById
{
    public class UpdateDriverHandler : IRequestHandler<UpdateDriverCommand>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public UpdateDriverHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }

        public async Task<Unit> Handle(UpdateDriverCommand command, CancellationToken cancellationToken)
        {
            var driverToUpdate = await _carsDriversContext.Drivers
                .Where(dr => dr.DriverId == command.Id)
                .FirstOrDefaultAsync(cancellationToken);
            
            driverToUpdate.FirstName = command.FirstName ?? driverToUpdate.FirstName;
            driverToUpdate.SecondName = command.SecondName ?? driverToUpdate.SecondName;
            driverToUpdate.Occupation = command.Occupation ?? driverToUpdate.Occupation;
            
            await _carsDriversContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}