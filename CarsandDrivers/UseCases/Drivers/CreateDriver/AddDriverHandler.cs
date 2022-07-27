using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using CarsAndDrivers.Infrastructure.Entities;
using MediatR;

namespace CarsAndDrivers.UseCases.Drivers.CreateDriver
{
    public class AddDriverHandler : IRequestHandler<AddDriverCommand, Unit>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public AddDriverHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }

        public async Task<Unit> Handle(AddDriverCommand command, CancellationToken cancellationToken)
        {
            var newDriver = new Driver()
            {
                FirstName = command.FirstName,
                SecondName = command.SecondName,
                Occupation = command.Occupation
            };
            
            await _carsDriversContext.AddAsync(newDriver, cancellationToken);
            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;

        }
    }
}