using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Entities;
using CarsAndDrivers.UseCases.Cars.CarsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Cars.UpdateCarById
{
    public class UpdateCarByIdHandler : IRequestHandler<UpdateCarByIdCommand>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public UpdateCarByIdHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }

        public async Task<Unit> Handle(UpdateCarByIdCommand command, CancellationToken cancellationToken)
        {
            var carToUpdate = await _carsDriversContext.Cars
                .Where(cr => cr.CarId == command.Id)
                .FirstOrDefaultAsync(cancellationToken);
            
            carToUpdate.Model.Brand.BrandName = command.BrandName ?? carToUpdate.Model.Brand.BrandName;
            carToUpdate.Model.ModelName = command.ModelName ?? carToUpdate.Model.ModelName;

            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}