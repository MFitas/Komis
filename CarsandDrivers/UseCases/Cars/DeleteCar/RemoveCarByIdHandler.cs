using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Cars.DeleteCar
{
    public class RemoveCarByIdHandler : IRequestHandler<RemoveCarByIdCommand>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public RemoveCarByIdHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }

        public async Task<Unit> Handle(RemoveCarByIdCommand command, CancellationToken cancellationToken)
        {
            var carToRemove =  await _carsDriversContext.Cars
                .Where(cr => cr.CarId == command.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            
            _carsDriversContext.Remove(carToRemove);

            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}