using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using CarsAndDrivers.Infrastructure.Entities;
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
                BrandId = _carsDriversContext.CarBrands.Local.First(x=>x.BrandName == command.BrandName).BrandId,
                ModelName = command.ModelName.ToUpper()
            };

            await _carsDriversContext.AddAsync(newModel, cancellationToken);
            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}