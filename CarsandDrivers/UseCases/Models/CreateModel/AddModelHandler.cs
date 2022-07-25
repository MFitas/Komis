using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Cars;
using MediatR;

namespace CarsAndDrivers.UseCases.Models.CreateModel
{
    public class AddModelHandler : IRequestHandler<AddModelCommand, Unit>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public AddModelHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }

        public async Task<Unit> Handle(AddModelCommand command, CancellationToken cancellationToken)
        {
            var newModel = new CarModel()
            {
                ModelName = command.ModelName.ToUpper()
            };

            await _carsDriversContext.AddAsync(newModel, cancellationToken);
            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}