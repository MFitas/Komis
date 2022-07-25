using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Entities;
using MediatR;

namespace CarsAndDrivers.UseCases.Cars.CreateCar
{
   public class AddCarHandler : IRequestHandler<AddCarCommand, Unit>
        {
            private readonly CarsDriversContext _carsDriversContext;

            public AddCarHandler(CarsDriversContext context)
            {
                _carsDriversContext = context;
            }

            public async Task<Unit> Handle(AddCarCommand command, CancellationToken cancellationToken)
            {
                var newCar = new Car()
                {
                    Brand = command.Brand.ToUpper(),
                    Model = command.Model.ToUpper()
                };
            
                await _carsDriversContext.AddAsync(newCar, cancellationToken);
                await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
                return Unit.Value;

            }
        }
    
}