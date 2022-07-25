using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
                .FirstOrDefaultAsync();
            
            _carsDriversContext.Remove(carToRemove);

            await _carsDriversContext.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}