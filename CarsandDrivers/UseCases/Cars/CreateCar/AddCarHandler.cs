using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using CarsAndDrivers.Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
           
            var modelId =
                await _carsDriversContext.CarModels
                    .Select(md=> new
                    {
                        md.ModelName,
                        md.Brand,
                        md.ModelId
                    })
                    .Where(md=>md.Brand.BrandName == command.BrandName)
                    .FirstOrDefaultAsync(md => md.ModelName == command.ModelName, cancellationToken);

            var newCar = new Car()
            {
                ModelId = modelId.ModelId,
                BrandId = modelId.Brand.BrandId
                
            };

            await _carsDriversContext.AddAsync(newCar, cancellationToken);
            await _carsDriversContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}